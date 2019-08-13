using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting {

	public abstract class Draggable<T> : MonoBehaviour, IDropHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler {

		private Vector3 startPosition;
		private Vector3 diffPosition;

		public GameObject canvas;

		public void OnDrop(PointerEventData eventData) {
			
		}

		protected abstract void OnDropSucceeded(T recipient); 

		public void OnDrag(PointerEventData eventData) {
			transform.position = Input.mousePosition - diffPosition;
		}

		public void OnEndDrag(PointerEventData eventData) {

		}

		public void OnPointerClick(PointerEventData eventData) {
			Debug.Log("Clicked");
		}

		public void OnPointerDown(PointerEventData eventData) {
			//this.startPosition = transform.position;
			//this.diffPosition = Input.mousePosition - startPosition;
			//EventSystem.current.SetSelectedGameObject(gameObject);
			//EventSystem.current.currentSelectedGameObject.transform.SetParent(this.canvas.transform);
			//EventSystem.current.currentSelectedGameObject.transform.SetAsFirstSibling();
			Debug.Log("start drag " + gameObject.name);
		}

		protected virtual void Awake() {

		}

		protected virtual void Start() {

		}

		protected virtual void Update() {

		}

	}

}
