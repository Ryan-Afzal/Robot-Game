using Assets.Scripts.Scripting.Block;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting {
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(RectTransform))]
	public class PickupSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        public GameObject prefab;

        public RectTransform canvas;
        public Canvas canvasTransform;

        private Image image;
        private RectTransform rectTransform;

		public void Awake() {
            this.image = GetComponent<Image>();
            this.rectTransform = GetComponent<RectTransform>();

            var block = this.prefab.GetComponent<Block.Block>();
            if (block is null) {
                this.prefab.GetComponent<Argument>().canvas = this.canvas;
                this.prefab.GetComponent<Argument>().canvasTransform = this.canvasTransform;
            } else {
                block.canvas = this.canvas;
                block.canvasTransform = this.canvasTransform;
            }
		}

		public void Start() {

		}

		public void Update() {

		}

        #region Drag

        public void OnBeginDrag(PointerEventData eventData) {
            var newBlock = Instantiate(gameObject, this.canvas.transform).GetComponent<PickupSlot>();
            newBlock.canvas = this.canvas;
            newBlock.prefab = this.prefab;
        }

        public void OnDrag(PointerEventData eventData) {
            var screenPoint = Input.mousePosition;
            screenPoint.z = this.canvasTransform.planeDistance;
            this.rectTransform.position = this.canvasTransform.worldCamera.ScreenToWorldPoint(screenPoint);
        }

        public void OnEndDrag(PointerEventData eventData) {
            var list = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, list);

            if (list.Select(r => r.gameObject.GetComponent<TrashSlot>()).FirstOrDefault(s => s is object)) {
                Destroy(gameObject);
                return;
            }

            var results = list
                .Select(r => r.gameObject.GetComponent<PickupRect>())
                .Where(s => s is object);

            var obj = results.FirstOrDefault();

            if (obj is null) {
                var output = Instantiate(this.prefab, this.canvas.transform);
                output.transform.position = this.rectTransform.position;
            }

            Destroy(gameObject);
        }

        #endregion Drag



    }
}
