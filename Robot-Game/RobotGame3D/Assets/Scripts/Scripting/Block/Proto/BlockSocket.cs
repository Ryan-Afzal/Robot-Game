using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting.Block.Proto {

	[RequireComponent(typeof(RectTransform))]
	public class BlockSocket : MonoBehaviour {

		private RectTransform rectTransform;

		private Block parentBlock;

		private Block block;

		public void Awake() {
			this.rectTransform = GetComponent<RectTransform>();
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
			this.parentBlock.HierarchyChanged();
		}

		public void Attach(Block block) {
			if (this.block is null) {
				this.block = block;
				this.block.prevSocket = this;

				this.InvokeHierarchyChanged();
			} else {
				throw new InvalidOperationException();
			}
		}

		public void Detach() {
			if (this.block is object) {
				this.block.prevSocket = null;
				this.block = null;

				this.InvokeHierarchyChanged();
			}
		}

	}

}
