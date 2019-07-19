using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
	public class RoverControlScript : MonoBehaviour {

		public HingeJoint[] leftWheels;
		public HingeJoint[] rightWheels;

		private float currentSpeed;

		public float acceleration;
		public float maxSpeed;

		private void Start() {
			JointMotor motor = new JointMotor() {
				force = this.acceleration,
				targetVelocity = 0
			};

			foreach (var j in leftWheels) {
				j.useMotor = true;
				j.motor = motor;
			}

			foreach (var j in rightWheels) {
				j.useMotor = true;
				j.motor = motor;
			}
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

			JointMotor motor = new JointMotor() {
				force = this.acceleration,
				targetVelocity = this.currentSpeed
			};

			this.SetMotors(motor);
		}

		private void SetMotors(JointMotor motor) {
			JointMotor motorL = motor;
			JointMotor motorR = motor;

			//Tank Drive Here
			if (Input.GetKey(KeyCode.LeftArrow)) {
				motorL.targetVelocity *= 0.50f;
			} else if (Input.GetKey(KeyCode.RightArrow)) {
				motorR.targetVelocity *= 0.50f;
			}

			this.SetLMotors(motorL);
			this.SetRMotors(motorR);
		}

		private void SetLMotors(JointMotor motor) {
			foreach (var j in leftWheels) {
				j.useMotor = true;
				j.motor = motor;
			}
		}

		private void SetRMotors(JointMotor motor) {
			foreach (var j in rightWheels) {
				j.useMotor = true;
				j.motor = motor;
			}
		}
	}
}
