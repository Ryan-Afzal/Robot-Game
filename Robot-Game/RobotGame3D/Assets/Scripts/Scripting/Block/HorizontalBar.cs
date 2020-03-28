using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block {

	[RequireComponent(typeof(RectTransform))]
	public sealed class HorizontalBar : MonoBehaviour {

		public float spacing;

		private RectTransform rectTransform;

		public void Awake() {
			this.rectTransform = GetComponent<RectTransform>();
			var anchor = new Vector2(0.0f, 1.0f);
			this.rectTransform.anchorMin = anchor;
			this.rectTransform.anchorMax = anchor;
			this.rectTransform.pivot = anchor;
		}

		public void RecalculatePositions() {
			var children = transform.Cast<RectTransform>();

			float y = 0;

			foreach (var child in children) {
				y = Mathf.Max(y, child.rect.height);
			}

			float Dx = 0;

			foreach (var child in children) {
				float _y = (y - child.rect.height) / 2;

				child.localPosition = new Vector3(Dx, _y, 0);

				Dx += child.rect.width + this.spacing;
			}

			this.rectTransform.sizeDelta = new Vector2(Dx, y);
			this.rectTransform.ForceUpdateRectTransforms();
		}

	}

}
