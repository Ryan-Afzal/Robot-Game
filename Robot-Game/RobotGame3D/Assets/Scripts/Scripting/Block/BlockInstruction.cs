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

    public class BlockInstruction : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

        private Image image;
        private RectTransform rectTransform;
        
        private BlockInstruction prev;
        private BlockInstruction next;
        
        public void Awake() {
            this.image = GetComponent<Image>();
            this.rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData) {
            this.image.color = Color.green;
            this.rectTransform.parent = null;
            this.prev.next = null;
            this.prev = null;
        }

        public void OnDrag(PointerEventData eventData) {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData) {
            this.image.color = Color.white;
            
            var trash = FindObjectsOfType<TrashSlot>()
                .FirstOrDefault(o => Vector3.Distance(o.GetComponent<RectTransform>().position, this.rectTransform.position) < 50);
            
            if (trash is object) {
                Destroy(this.gameObject);
                return;
            }
            
            var result = FindObjectsOfType<BlockInstruction>()
                .FirstOrDefault(o => o != this && Vector3.Distance(o.rectTransform.position, this.rectTransform.position) < 50);

            if (result is object) {
                var resultTransform = result.GetComponent<RectTransform>();
                this.rectTransform.position = resultTransform.position + new Vector3(0, -100, 0);
                this.rectTransform.parent = resultTransform;
                this.prev = result;
                this.prev.next = this;
            }
        }
    }
    
}
