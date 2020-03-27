using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting.Block.Proto2 {

	[RequireComponent(typeof(RectTransform))]
	public class TestBlock : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        public Canvas canvas;

		private RectTransform rectTransform;

        internal BlockSocket prevSocket;

		public void Awake() {
			this.rectTransform = GetComponent<RectTransform>();
		}

		public void Start() {

		}

		public void Update() {

		}

        public void HierarchyChanged() {
            this.prevSocket?.InvokeHierarchyChanged();
        }

		public void OnGUI() {
			GUI.Label(this.rectTransform.rect, new GUIContent() { image = null });
		}

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
                .Select(r => r.gameObject)
                .Where(o => !ReferenceEquals(gameObject, o));

            var obj = results.FirstOrDefault(o => o.GetComponent<BlockSocket>() is object);

            if (obj is object) {
                var result = obj.GetComponent<BlockSocket>();
                var resultTransform = result.GetComponent<RectTransform>();

                this.rectTransform.position = resultTransform.position + new Vector3();
                this.rectTransform.SetParent(resultTransform, true);

                result.Attach(this);
            }
        }

        #endregion Drag

    }

}
