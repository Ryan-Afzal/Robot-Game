using Assets.Scripts.Robot;
using Assets.Scripts.Robot.Motion;
using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
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

		private readonly Dictionary<string, int> rotaryActuatorNamesToIndices = new Dictionary<string, int>() {
			{ "wheelActuatorFL", 0 }, 
			{ "wheelActuatorFR", 1 }, 
			{ "wheelActuatorBL", 2 }, 
			{ "wheelActuatorBR", 3 }, 
			{ "turnActuatorFL", 4 }, 
			{ "turnActuatorFR", 5 }
		};

		private readonly Dictionary<string, int> linearActuatorNamesToIndices = new Dictionary<string, int>() {
			{ "pushPlateActuator", 0 }
		};

		public float maxSpeed;

		private float currentSpeed;

		private void Awake() {
			this.currentSpeed = 0.0f;
		}

		private async void Start() {
			IInstruction instruction = new IfInstruction(
				new IInstruction[] { new RotaryActuatorSetSpeedInstruction(new IArgInstruction[] { new LiteralArgInstruction(0), new LiteralArgInstruction(10f) }) }, 
				new IArgInstruction[] { new LiteralArgInstruction(false) }
				);

			await instruction.Execute(new InstructionExecutionArgs() { Robot = this.robotBase });
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				if (this.currentSpeed < this.maxSpeed) {
					this.currentSpeed++;
				}
			}
			
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				if (this.currentSpeed > (-this.maxSpeed)) {
					this.currentSpeed--;
				}
			}

			if (Input.GetKeyDown(KeyCode.Space)) {
				this.currentSpeed = 0.0f;
			}

			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["wheelActuatorFL"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["wheelActuatorFR"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["wheelActuatorBL"]].SetActuatorSpeed(this.currentSpeed);
			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["wheelActuatorBR"]].SetActuatorSpeed(this.currentSpeed);

			float targetTurnRotation = 0.0f;

			if (Input.GetKey(KeyCode.LeftArrow)) {
				targetTurnRotation = 45.0f;
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				targetTurnRotation = -45.0f;
			}

			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["turnActuatorFL"]].RotateActuatorTo(targetTurnRotation);
			this.robotBase.rotaryActuatorManagers[this.rotaryActuatorNamesToIndices["turnActuatorFR"]].RotateActuatorTo(targetTurnRotation);

			if (Input.GetKeyDown(KeyCode.A)) {
				int index = this.linearActuatorNamesToIndices["pushPlateActuator"];
				throw new NotImplementedException();
			}

			if (Input.GetKeyDown(KeyCode.S)) {
				this.robotBase.linearActuatorManagers[this.linearActuatorNamesToIndices["pushPlateActuator"]].FullRetractActuator();
			}
		}


	}
}
