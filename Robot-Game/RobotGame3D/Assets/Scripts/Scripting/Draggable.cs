using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting {

	public abstract class Draggable<T> : MonoBehaviour, IDropHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler {

		public void OnDrop(PointerEventData eventData) {
			Debug.Log("Drop");
		}

		protected abstract void OnDrag();
		protected abstract void OnDrop(T recipient); 

		public void OnDrag(PointerEventData eventData) {
			Debug.Log("Drag");
		}

		public void OnEndDrag(PointerEventData eventData) {

		}

		public void OnPointerClick(PointerEventData eventData) {
			Debug.Log("Clicked");
		}

		public void OnPointerDown(PointerEventData eventData) {
			Debug.Log("PointerDown");
		}

		protected virtual void Awake() {

		}

		protected virtual void Start() {

		}

		protected virtual void Update() {

		}

	}

}
