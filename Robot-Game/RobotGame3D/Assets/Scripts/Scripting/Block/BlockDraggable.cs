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

    public abstract class BlockDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        public struct OnEndDragArgs {
            public PointerEventData EventData { get; set; }
            public BlockDraggable FoundObject { get; set; }
        }

        public Vector3 offset = new Vector3(0, -100, 0);

        public Canvas canvas;

        protected RectTransform rectTransform;

        public event Action<PointerEventData> onBeginDrag, onDrag;
        public event Action<OnEndDragArgs> onEndDrag;

        public bool Locked { get; set; }

        protected BlockDraggable Previous { get; private set; }
        protected BlockDraggable Next { get; private set; }

        public void Awake() {
            this.rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            if (!Locked) {
                this.rectTransform.SetParent(this.canvas.transform);

                Previous.Next = null;
                Previous = null;

                this.onBeginDrag?.Invoke(eventData);
            }
        }

        public void OnDrag(PointerEventData eventData) {
            if (!Locked) {
                transform.position = eventData.position;

                this.onDrag?.Invoke(eventData);
            }
        }

        public void OnEndDrag(PointerEventData eventData) {
            if (!Locked) {
                var result = FindObjectsOfType<BlockDraggable>()
                    .FirstOrDefault(o => o != this && Vector3.Distance(o.rectTransform.position, this.rectTransform.position) < 50);

                var args = new OnEndDragArgs() { EventData = eventData, FoundObject = result };

                if (result is object && this.CanDrop(args)) {
                    var resultTransform = result.GetComponent<RectTransform>();
                    this.rectTransform.position = resultTransform.position + this.offset;
                    this.rectTransform.SetParent(resultTransform, false);
                    Previous = result;
                    Previous.Next = this;
                }

                this.onEndDrag?.Invoke(args);
            }
        }

        protected abstract bool CanDrop(OnEndDragArgs args);
    }

}
