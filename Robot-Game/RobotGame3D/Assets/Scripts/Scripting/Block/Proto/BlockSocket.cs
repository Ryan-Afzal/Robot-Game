using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting.Block.Proto {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(RectTransform))]
	public class BlockSocket : MonoBehaviour {

		public static readonly Vector2 baseDelta = new Vector2(100, 25);

		private Image image;
		private RectTransform rectTransform;

		internal Block parentBlock;

		private Block block;

		public void Awake() {
			this.image = GetComponent<Image>();
			this.rectTransform = GetComponent<RectTransform>();

			this.image.enabled = true;
			this.rectTransform.sizeDelta = baseDelta;

			this.block = null;
		}

		public void Start() {

		}

		public void Update() {

		}

		public void SetParentBlock(Block block) {
			this.parentBlock = block;
		}

		public void InvokeHierarchyChanged() {
			this.parentBlock?.HierarchyChanged();
		}

		public void Attach(Block block) {
			if (this.block is null) {
				this.block = block;
				this.block.prevSocket = this;

				this.image.enabled = false;
				var blockTrans = block.GetComponent<RectTransform>();
				this.rectTransform.sizeDelta = new Vector2(
					blockTrans.rect.width
						- block.padding.x
						- block.padding.y, 
					blockTrans.rect.height
						- block.padding.z
						- block.padding.w
					);

				this.InvokeHierarchyChanged();
			} else {
				throw new InvalidOperationException();
			}
		}

		public void Detach() {
			if (this.block is object) {
				this.block.prevSocket = null;
				this.block = null;

				this.image.enabled = true;
				this.rectTransform.sizeDelta = baseDelta;

				this.InvokeHierarchyChanged();
			}
		}

	}

}
