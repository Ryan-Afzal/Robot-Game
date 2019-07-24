using Assets.Scripts.Robot;
using Assets.Scripts.Robot.Motion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
	/// <summary>
	/// A control script using a car-style driving and turn system. 
	/// All wheels are turned at the same rate, 
	/// however there are two actuators on the front wheels, 
	/// which turn the front wheels around their secondary axes.
	/// </summary>
	public class RoverControlScript : MonoBehaviour {

		public RobotBase robotBase;
		private Dictionary<string, int> actuatorNamesToIndices = new Dictionary<string, int>() {
			{ "wheelActuatorFL", 0 }, 
			{ "wheelActuatorFR", 1 }, 
			{ "wheelActuatorBL", 2 }, 
			{ "wheelActuatorBR", 3 }, 
			{ "turnActuatorFL", 4 }, 
			{ "turnActuatorFR", 5 }
		};

		public float maxSpeed;

		private float currentSpeed;

		private void Awake() {
			this.currentSpeed = 0.0f;
		}

		private void Start() {
			
		}

		private void Update() {
			if (Input.GetKey(KeyCode.UpArrow)) {
				if (this.currentSpeed < this.maxSpeed) {
					this.currentSpeed++;
				}
			}
			
			if (Input.GetKey(KeyCode.DownArrow)) {
				if (this.currentSpeed > (-this.maxSpeed)) {
					this.currentSpeed--;
				}
			}

			if (Input.GetKey(KeyCode.Space)) {
				this.currentSpeed = 0.0f;
			}

			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["wheelActuatorFL"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["wheelActuatorFR"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["wheelActuatorBL"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["wheelActuatorBR"]].SetActuatorSpeed(this.currentSpeed);

			float targetTurnRotation = 0.0f;

			if (Input.GetKey(KeyCode.LeftArrow)) {
				targetTurnRotation = 45.0f;
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				targetTurnRotation = -45.0f;
			}

			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["turnActuatorFL"]].RotateActuatorTo(targetTurnRotation);
			this.robotBase.rotaryActuatorManagers[this.actuatorNamesToIndices["turnActuatorFR"]].RotateActuatorTo(targetTurnRotation);
		}


	}
}
