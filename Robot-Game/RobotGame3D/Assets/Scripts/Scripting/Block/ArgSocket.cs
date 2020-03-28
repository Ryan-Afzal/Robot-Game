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

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Shadow))]
	[RequireComponent(typeof(RectTransform))]
	public sealed class ArgSocket : MonoBehaviour {

		private Image image;
		private Shadow shadow;
		private RectTransform rectTransform;

		private Argument argument;

		public void Awake() {
			this.image = GetComponent<Image>();
			this.shadow = GetComponent<Shadow>();
			this.rectTransform = GetComponent<RectTransform>();
		}

		public void Start() {

		}

		public void Update() {

		}

		public void Detach() {
			this.argument.Base = null;
			this.argument = null;
		}

		public void Attach(Argument argument) {
			this.argument = argument;
			this.argument.Base = this;
		}

	}

}
