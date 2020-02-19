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

    public abstract class BlockInstruction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        public string startText;
        public string[] text;

        private Image image;
        private Shadow shadow;
        private RectTransform rectTransform;

        public Vector3 offset = new Vector3(0, -100, 0);

        public Canvas canvas;

        public bool Locked { get; set; }

        public BlockInstruction Previous { get; set; }
        public BlockInstruction Next { get; set; }

        public void Awake() {
            this.rectTransform = GetComponent<RectTransform>();
            this.image = GetComponent<Image>();
            this.shadow = GetComponent<Shadow>();
        }

        public virtual void Start() {

        }

        public virtual void Update() {
            this.shadow.enabled = RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, Input.mousePosition);
        }

        private void SetColorDrag() {
            this.image.color = Color.green;
        }

        private void SetColorEndDrag() {
            this.image.color = Color.white;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (!Locked) {
                this.rectTransform.SetParent(this.canvas.transform, true);

                if (Previous is object) {
                    Previous.Next = null;
                    Previous = null;
                }

                SetColorDrag();
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (!Locked) {
                transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!Locked) {
                var list = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventData, list);

                var results = list
                    .Select(r => r.gameObject)
                    .Where(o => !ReferenceEquals(this.gameObject, o));

                if (results.FirstOrDefault(o => o.GetComponent<TrashSlot>() is object) is object) {
                    Destroy(gameObject);
                    return;
                }

                var obj = results.FirstOrDefault(o => o.GetComponent<BlockInstruction>() is object);

                if (obj is object) {
                    var result = obj.GetComponent<BlockInstruction>();
                    var resultTransform = result.GetComponent<RectTransform>();

                    this.rectTransform.position = resultTransform.position + this.offset;
                    this.rectTransform.SetParent(resultTransform, true);

                    Previous = result;
                    Previous.Next = this;
                }

                SetColorEndDrag();
            }
        }

        public abstract IInstruction GetCompiledInstruction();

    }

}
