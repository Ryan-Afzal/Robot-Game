using Assets.Scripts.Robot.Motion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {

	public class LinearActuatorTestScript : MonoBehaviour {

		public LinearActuatorManager manager;

		private void Awake() {
			manager.hasExtensionLimit = true;
			manager.extensionLimit = 100f;
			manager.extensionSpeed = 1f;
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				manager.ExtendActuatorBy(5);
			}

			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				manager.ExtendActuatorBy(-5);
			}
		}

	}

}