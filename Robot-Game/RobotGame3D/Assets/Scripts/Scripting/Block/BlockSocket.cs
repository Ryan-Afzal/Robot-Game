using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting.Block {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(RectTransform))]
	public sealed class BlockSocket : MonoBehaviour {

		public static readonly Vector2 baseDelta = new Vector2(100, 25);

		private Image image;
		private Shadow shadow;
		private RectTransform rectTransform;

		internal Block parentBlock;

		public Block AttachedBlock { get; private set; }

		public void Awake() {
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.rectTransform = GetComponent<RectTransform>();

			this.image.enabled = true;

			AttachedBlock = null;

			this.RecalculateSize();
		}

		public void Start() {
			this.RecalculateSize();
		}

		public void Update() {

		}

		public void OnMouseEnter() {
			if (AttachedBlock is null) {
				this.shadow.enabled = true;
			}
		}

		public void OnMouseExit() {
			this.shadow.enabled = false;
		}

		public void SetParentBlock(Block block) {
			this.parentBlock = block;
		}

		public void InvokeHierarchyChanged() {
			this.RecalculateSize();

			this.parentBlock?.HierarchyChanged();
		}

		public void Attach(Block block) {
			if (AttachedBlock is null) {
				AttachedBlock = block;
				AttachedBlock.prevSocket = this;

				this.image.enabled = false;

				this.InvokeHierarchyChanged();
			} else {
				throw new InvalidOperationException();
			}
		}

		public void Detach() {
			if (AttachedBlock is object) {
				AttachedBlock.prevSocket = null;
				AttachedBlock = null;

				this.image.enabled = true;

				this.InvokeHierarchyChanged();
			}
		}

		private void RecalculateSize() {
			if (AttachedBlock is null) {
				this.rectTransform.sizeDelta = new Vector2(Mathf.Min(baseDelta.x, parentBlock?.GetTotalSize().x ?? baseDelta.x), baseDelta.y);
			} else {
				var blockSize = AttachedBlock.GetTotalSize();
				this.rectTransform.sizeDelta = blockSize - new Vector2(AttachedBlock.Padding.x + AttachedBlock.Padding.y, 0);
			}
		}

	}

}
