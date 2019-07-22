using Assets.Scripts.Robot.Motion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
	public class RoverControlScript : MonoBehaviour {

		public RotaryActuatorManager[] leftWheels;
		public RotaryActuatorManager[] rightWheels;

		private float currentSpeed;

		public float acceleration;
		public float maxSpeed;

		private void Awake() {
			
		}

		private void Start() {
			
		}

		private void Update() {
			if (Input.GetKey(KeyCode.UpArrow)) {
				if (Mathf.Abs(this.currentSpeed) < maxSpeed) {
					this.currentSpeed++;
				}
			} else if (Input.GetKey(KeyCode.DownArrow)) {
				if (Mathf.Abs(this.currentSpeed) < maxSpeed) {
					this.currentSpeed--;
				}
			} else {
				if (this.currentSpeed < 0) {
					this.currentSpeed++;
				} else if (this.currentSpeed > 0) {
					this.currentSpeed--;
				}
			}

			this.SetActuators(this.currentSpeed);
		}

		private void SetActuators(float speed) {
			float speedL = speed;
			float speedR = speed;

			if (Input.GetKey(KeyCode.LeftArrow)) {
				speedR *= 0.50f;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				speedL *= 0.50f;
			}

			this.SetLActuators(speedL);
			this.SetRActuators(speedR);
		}

		private void SetLActuators(float speed) {
			foreach (var j in leftWheels) {
				j.SetActuatorSpeed(speed);
			}
		}

		private void SetRActuators(float speed) {
			foreach (var j in rightWheels) {
				j.SetActuatorSpeed(speed);
			}
		}
	}
}
