using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block.Proto {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(GridLayoutGroup))]
	[RequireComponent(typeof(RectTransform))]
	public class Block2 : MonoBehaviour {

		// Editor
		public ArgSocket argSocketPrefab;
		public Text textPrefab;

		public Canvas canvas;
		public string startText;
		public string[] text;

		// Components
		private RectTransform rectTransform;
		private Image image;
		private Shadow shadow;
		private GridLayoutGroup gridLayoutGroup;

		// Fields
		private ArgSocket[] argSockets;
		private Text[] textCells;

		public BlockSocket Base { get; set; }

		protected event Action onHierarchyChanged;

		public void Awake() {
			this.rectTransform = GetComponent<RectTransform>();
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.gridLayoutGroup = GetComponent<GridLayoutGroup>();

			this.IntializeTextAndArgSockets(this.startText, this.text);
		}

		private void IntializeTextAndArgSockets(string startText, string[] textCells) {
			this.textCells = new Text[textCells.Length + 1];
			this.argSockets = new ArgSocket[textCells.Length];
			
			this.textCells[0] = Instantiate(this.textPrefab, this.rectTransform);
			this.textCells[0].text = startText;

			for (int i = 0; i < textCells.Length; i++) {
				this.argSockets[i] = Instantiate(this.argSocketPrefab, this.rectTransform);

				this.textCells[i + 1] = Instantiate(this.textPrefab, this.rectTransform);
				this.textCells[i + 1].text = textCells[i];
			}

			this.rectTransform.ForceUpdateRectTransforms();
			this.gridLayoutGroup.CalculateLayoutInputHorizontal();
		}

		public void Start() {
			this.onHierarchyChanged.Invoke();
		}

		public void Update() {
			if (Input.GetKeyDown(KeyCode.U)) {
				this.onHierarchyChanged.Invoke();
			}
		}

		#region Drag

		public void OnBeginDrag(PointerEventData eventData) {
			this.rectTransform.SetParent(this.canvas.transform, true);

			if (Base is object) {
				Base.Block.onHierarchyChanged.Invoke();
				Base.Detach();
			}
		}

		public void OnDrag(PointerEventData eventData) {
			this.rectTransform.position = eventData.position;
		}

		public void OnEndDrag(PointerEventData eventData) {
			var list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData, list);

			var results = list
				.Select(r => r.gameObject)
				.Where(o => !ReferenceEquals(this.gameObject, o));

			var obj = results.FirstOrDefault(o => o.GetComponent<BlockSocket>() is object);

			if (obj is object) {
				var result = obj.GetComponent<BlockSocket>();
				var resultTransform = result.GetComponent<RectTransform>();

				this.rectTransform.position = resultTransform.position + new Vector3(0, 0, 0);
				this.rectTransform.SetParent(resultTransform, true);

				result.Attach(this);
				result.Block.onHierarchyChanged.Invoke();
			}
		}

		#endregion Drag

	}

}
