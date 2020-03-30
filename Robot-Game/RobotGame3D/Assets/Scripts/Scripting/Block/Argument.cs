using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(RectTransform))]
	public abstract class Argument : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IHierarchyChangedHandler {

		// Prefabs
		public HorizontalBar horizontalBarPrefab;
		public Text textPrefab;
		public ArgSocket argSocketPrefab;

		// Inspector Parameters
		public Canvas canvas;

		private Image image;
		private Shadow shadow;
		private RectTransform rectTransform;

		internal ArgSocket prevSocket;

		protected ArgSocket[] argSockets;
		public virtual Vector4 Padding => new Vector4(10, 10, 10, 10);

		protected abstract float VerticalSpacing { get; }
		protected abstract string[] Text { get; }

		public void Awake() {
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.rectTransform = GetComponent<RectTransform>();

			this.shadow.enabled = false;

			var anchor = new Vector2(0.0f, 1.0f);
			this.rectTransform.anchorMin = anchor;
			this.rectTransform.anchorMax = anchor;
			this.rectTransform.pivot = anchor;

			this.rectTransform.SetParent(this.canvas.transform, true);

			this.InitializeTextAndArgSockets(Text);
		}

		public void Start() {
			this.HierarchyChanged();
		}

		#region Layout

		public Vector2 GetTotalSize() {
			return this.rectTransform.sizeDelta;
		}

		public void HierarchyChanged() {
			this.RecalculatePositions();

			this.prevSocket?.InvokeHierarchyChanged();
		}

		private void RecalculatePositions() {
			var children = this.rectTransform
				.Cast<RectTransform>()
				.ToArray();

			if (children.Length == 0) {
				throw new InvalidOperationException("There should be more children");
			}

			float x = -Padding.x;

			for (int i = 0; i < children.Length; i++) {
				var child = children[i];
				child.GetComponent<HorizontalBar>()?.RecalculatePositions();

				x = Mathf.Max(x, child.rect.width);
			}

			float Dy = -Padding.z;

			for (int i = 0; i < children.Length; i++) {
				var child = children[i];

				child.localPosition = new Vector3(Padding.x, Dy, 0);

				Dy -= child.rect.height + VerticalSpacing;
			}

			this.rectTransform.sizeDelta = new Vector2(x + Padding.x + Padding.y, (-Dy) + Padding.z + Padding.w);
			this.rectTransform.ForceUpdateRectTransforms();
		}

		public void InitializeTextAndArgSockets(string[] text) {
			int i = 0;

			this.argSockets = new ArgSocket[text.Length];

			// Populate row
			var bar = Instantiate(this.horizontalBarPrefab, this.rectTransform);

			var firstText = Instantiate(this.textPrefab, bar.transform);
			firstText.text = text[0];

			for (int k = 1; k < text.Length; k++) {
				this.argSockets[i] = Instantiate(this.argSocketPrefab, bar.transform);
				this.argSockets[i].SetParent(this);
				i++;

				var rowText = Instantiate(this.textPrefab, bar.transform);
				rowText.text = text[k];
			}
		}

		#endregion Layout

		#region Drag

		public void OnBeginDrag(PointerEventData eventData) {
			this.rectTransform.SetParent(this.canvas.transform, true);

			this.prevSocket?.Detach();
		}

		public void OnDrag(PointerEventData eventData) {
			transform.position = eventData.position;
		}

		public void OnEndDrag(PointerEventData eventData) {
			var list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData, list);

			var results = list
				.Select(r => r.gameObject.GetComponent<ArgSocket>())
				.Where(s => s is object);

			var obj = results.FirstOrDefault(s => this.NoCycle(s));

			if (obj is object) {
				var result = obj.GetComponent<ArgSocket>();
				var resultTransform = result.GetComponent<RectTransform>();

				this.rectTransform.SetParent(resultTransform, true);
				this.rectTransform.localPosition = new Vector3(0, 0, 0);

				result.Attach(this);
			}
		}

		private bool NoCycle(ArgSocket socket) {
			return !this.rectTransform
				.Cast<RectTransform>()
				.Select(t => t.GetComponent<ArgSocket>())
				.Any(s => ReferenceEquals(s, socket));
		}

		#endregion Drag

		public abstract IArgInstruction Compile();

	}

}
