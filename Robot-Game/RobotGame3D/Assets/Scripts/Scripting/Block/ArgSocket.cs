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
	public sealed class ArgSocket : MonoBehaviour {

		public static readonly Vector2 baseDelta = new Vector2(100, 25);

		private Image image;
		private Shadow shadow;
		private RectTransform rectTransform;

		internal IHierarchyChangedHandler parent;

		public Argument AttachedArgument { get; private set; }

		public void Awake() {
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.rectTransform = GetComponent<RectTransform>();

			this.image.enabled = true;
			this.rectTransform.sizeDelta = baseDelta;
			this.rectTransform.ForceUpdateRectTransforms();

			AttachedArgument = null;
		}

		public void Start() {

		}

		public void Update() {

		}

		public void OnMouseEnter() {
			if (AttachedArgument is null) {
				this.shadow.enabled = true;
			}
		}

		public void OnMouseExit() {
			this.shadow.enabled = false;
		}

		public void SetParent(IHierarchyChangedHandler parent) {
			this.parent = parent;
		}

		public void InvokeHierarchyChanged() {
			this.RecalculateSize();

			this.parent?.HierarchyChanged();
		}

		public void Attach(Argument argument) {
			if (AttachedArgument is null) {
				AttachedArgument = argument;
				AttachedArgument.prevSocket = this;

				this.image.enabled = false;

				this.InvokeHierarchyChanged();
			} else {
				throw new InvalidOperationException();
			}
		}

		public void Detach() {
			if (AttachedArgument is object) {
				AttachedArgument.prevSocket = null;
				AttachedArgument = null;

				this.image.enabled = true;

				this.InvokeHierarchyChanged();
			}
		}

		private void RecalculateSize() {
			if (AttachedArgument is null) {
				this.rectTransform.sizeDelta = baseDelta;
			} else {
				var argSize = AttachedArgument.GetTotalSize();
				this.rectTransform.sizeDelta = argSize;
			}
		}

	}

}
