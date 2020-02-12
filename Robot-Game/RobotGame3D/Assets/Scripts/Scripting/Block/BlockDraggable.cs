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
    
    public abstract class BlockDraggable<T> : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
        
        protected struct OnEndDragArgs<T> {
            public PointerEventData EventData { get; set; }
            public T FoundObject { get; set; }
        }
        
        public bool locked;
        
        public Vector3 offset = new Vector3(0, -100, 0);

        public Canvas canvas;
        
        private RectTransform rectTransform;
        
        private T prev;
        protected T next;
        
        public event Action<PointerEventData> onBeginDrag, onDrag, onBeforeEndDrag;
        public event Action<OnEndDragArgs<T>> onEndDrag;
        
        public void Awake() {
            this.image = GetComponent<Image>();
            this.rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (!this.locked) {
                this.rectTransform.SetParent(this.canvas.transform);

                if (this.prev is object) {
                    this.prev.next = null;
                    this.prev = null;
                }
                
                this.onBeginDrag?.Invoke(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (!this.locked) {
                transform.position = eventData.position;
                
                this.onDrag?.Invoke(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!this.locked) {
                this.onBeforeEndDrag?.Invoke(eventData);
                
                var result = FindObjectsOfType<T>()
                    .FirstOrDefault(o => o != this && Vector3.Distance(o.rectTransform.position, this.rectTransform.position) < 50);

                if (result is object) {
                    var resultTransform = result.GetComponent<RectTransform>();
                    this.rectTransform.position = resultTransform.position + this.offset;
                    this.rectTransform.SetParent(resultTransform, false);
                    this.prev = result;
                    this.prev.next = this;
                }
                
                this.onEndDrag?.Invoke(new OnEndDragArgs() { EventData = eventData, FoundObject = result });
            }
        }
    }
    
}
