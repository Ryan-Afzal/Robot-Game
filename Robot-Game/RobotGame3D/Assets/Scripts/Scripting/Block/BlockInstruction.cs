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

        public bool locked;

        public string startText;
        public string[] text;

        public Canvas canvas;
        
        private Image image;
        private RectTransform rectTransform;
        
        private BlockInstruction prev;
        protected BlockInstruction next;
        
        public void Awake() {
            this.image = GetComponent<Image>();
            this.rectTransform = GetComponent<RectTransform>();
        }

        public virtual void Start() {

        }

        public abstract IInstruction GetCompiledInstruction();

        public void OnBeginDrag(PointerEventData eventData) {
            if (!this.locked) {
                this.image.color = Color.green;
                this.rectTransform.SetParent(this.canvas.transform);

                if (this.prev is object) {
                    this.prev.next = null;
                    this.prev = null;
                }
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (!this.locked) {
                transform.position = eventData.position;
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!this.locked) {
                this.image.color = Color.white;

                var trash = FindObjectsOfType<TrashSlot>()
                    .FirstOrDefault(o => Vector3.Distance(o.GetComponent<RectTransform>().position, this.rectTransform.position) < 50);

                if (trash is object) {
                    Destroy(gameObject);
                    return;
                }

                var result = FindObjectsOfType<BlockInstruction>()
                    .FirstOrDefault(o => o != this && Vector3.Distance(o.rectTransform.position, this.rectTransform.position) < 50);

                if (result is object) {
                    var resultTransform = result.GetComponent<RectTransform>();
                    this.rectTransform.position = resultTransform.position + new Vector3(0, -100, 0);
                    this.rectTransform.SetParent(resultTransform, false);
                    this.prev = result;
                    this.prev.next = this;
                }
            }
        }
    }
    
}
