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
	public sealed class ArgSocket : MonoBehaviour {

		private RectTransform rectTransform;
		private Image image;
		private Shadow shadow;

		private bool visible;

		public bool Visible {
			
			get {
				return this.visible;
			}

			set {
				this.visible = value;
				this.image.enabled = value;
			}

		}

		public IHierarchyChangeHandler Base { get; set; }
		public BlockArgument Argument { get; set; }

		public void Awake() {
			this.rectTransform = GetComponent<RectTransform>();
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
		}

		public void Update() {
			this.shadow.enabled = Visible ? RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, Input.mousePosition) : false;
		}

		public void HierarchyChanged() {
			Argument.HierarchyChanged();
		}

	}
}
