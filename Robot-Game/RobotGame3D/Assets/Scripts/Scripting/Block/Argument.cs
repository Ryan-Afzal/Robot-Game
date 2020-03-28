using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(RectTransform))]
	public class Argument : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

		public Canvas canvas;

		private Image image;
		private Shadow shadow;
		private RectTransform rectTransform;

		public ArgSocket Base { get; set; }

		public void Awake() {
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.rectTransform = GetComponent<RectTransform>();
		}

		public void Start() {

		}

		public void Update() {
			this.shadow.enabled = RectTransformUtility.RectangleContainsScreenPoint(this.rectTransform, Input.mousePosition);
		}

		public void OnBeginDrag(PointerEventData eventData) {
			this.rectTransform.SetParent(this.canvas.transform, true);

			if (Base is object) {
				Base.Detach();
			}
		}

		public void OnDrag(PointerEventData eventData) {
			this.rectTransform.position = eventData.position;
		}

		public void OnEndDrag(PointerEventData eventData) {
			var list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(eventData, list);

			var results = list
				.Select(r => r.gameObject)
				.Where(o => !ReferenceEquals(this.gameObject, o));

			var obj = results.FirstOrDefault(o => o.GetComponent<ArgSocket>() is object);

			if (obj is object) {
				var result = obj.GetComponent<ArgSocket>();
				var resultTransform = result.GetComponent<RectTransform>();

				this.rectTransform.position = resultTransform.position + new Vector3(0, 0, 0);
				this.rectTransform.SetParent(resultTransform, true);

				result.Attach(this);
			}
		}

	}

}
