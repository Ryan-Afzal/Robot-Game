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

        public Vector3 offset = new Vector3(0, -100, 0);

        public Canvas canvas;

        public bool Locked { get; set; }

        public BlockInstruction Previous { get; set; }
        public BlockInstruction Next { get; set; }

        public RectTransform RectTransform { get; set; }

        public void Awake() {
            RectTransform = GetComponent<RectTransform>();
            this.image = GetComponent<Image>();
        }

        public virtual void Start() {

        }

        private void SetColorDrag() {
            this.image.color = Color.green;
        }

        private void SetColorEndDrag() {
            this.image.color = Color.white;
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (!Locked) {
                RectTransform.SetParent(this.canvas.transform);

                Previous.Next = null;
                Previous = null;

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
                var trash = FindObjectsOfType<TrashSlot>()
                    .FirstOrDefault(o => Vector3.Distance(o.GetComponent<RectTransform>().position, RectTransform.position) < 50);

                if (trash is object) {
                    Destroy(gameObject);
                    return;
                }

                var result = FindObjectsOfType<BlockInstruction>()
                    .FirstOrDefault(o => o != this && Vector3.Distance(o.RectTransform.position, this.RectTransform.position) < 50);

                if (result is object) {
                    var resultTransform = result.GetComponent<RectTransform>();

                    RectTransform.position = resultTransform.position + this.offset;
                    RectTransform.SetParent(resultTransform, false);

                    Previous = result;
                    Previous.Next = this;

                    SetColorEndDrag();
                }
            }
        }

        public abstract IInstruction GetCompiledInstruction();

    }
    
}
