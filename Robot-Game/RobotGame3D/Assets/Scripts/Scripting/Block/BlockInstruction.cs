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
    
    public abstract class BlockInstruction : BlockDraggable {

        public string startText;
        public string[] text;
        
        private Image image;
        
        public virtual void Start() {
			this.image = GetComponent<Image>();

			this.onBeginDrag += this.SetColorDrag;
			this.onEndDrag += this.SetColorEndDrag;
		}

        public abstract IInstruction GetCompiledInstruction();

		private void SetColorDrag(PointerEventData eventData) {
			this.image.color = Color.green;
		}

		private void SetColorEndDrag(OnEndDragArgs args) {
			this.image.color = Color.white;
		}

		protected override bool CanDrop(OnEndDragArgs args) {
			var trash = FindObjectsOfType<TrashSlot>()
					.FirstOrDefault(o => Vector3.Distance(o.GetComponent<RectTransform>().position, this.rectTransform.position) < 50);

			if (trash is object) {
				Destroy(gameObject);
				return false;
			} else {
				return true;
			}
		}
    }
    
}
