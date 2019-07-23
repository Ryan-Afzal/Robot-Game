using Assets.Scripts.Robot.Motion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {

	public class RotaryActuatorTestScript : MonoBehaviour {

		public RotaryActuatorManager manager;

		private void Awake() {
			manager.hasRotationLimit = false;
			manager.rotationSpeed = 1;
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				manager.IncreaseActuatorSpeedBy(-15);
			}

			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				manager.IncreaseActuatorSpeedBy(15);
			}
		}

	}

}