using Assets.Scripts.Robot;
using Assets.Scripts.Robot.Motion;
using Assets.Scripts.Scripting.Block;
using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting {

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(RectTransform))]
	public class ResetButton : MonoBehaviour {

		public RotaryActuatorManager basePlate;
		public RotaryActuatorManager lowerArm;
		public RotaryActuatorManager upperArm;
		public MagnetManager magnet;
		public Box box;

		public Canvas canvas;

		private Image image;
		private Button button;
		private RectTransform rectTransform;

		private Color tint = new Color(55, 55, 55);

		public void Awake() {
			this.image = GetComponent<Image>();
			this.button = GetComponent<Button>();
			this.rectTransform = GetComponent<RectTransform>();

			this.DisablePress();
		}

		public void Start() {
			this.EnablePress();
		}

		private void EnablePress() {
			this.button.enabled = true;
			this.image.color += this.tint;
		}

		private void DisablePress() {
			this.button.enabled = false;
			this.image.color -= this.tint;
		}

		public void OnButtonPressed() {
			this.basePlate.Reset();
			this.lowerArm.Reset();
			this.upperArm.Reset();
			this.magnet.Reset();
			this.box.Reset();
		}

	}
}
