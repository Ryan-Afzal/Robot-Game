using Assets.Scripts.Robot.Motion;
using Assets.Scripts.Robot.Sensor;
using Assets.Scripts.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot {

	public class RobotBase : MonoBehaviour {

		public LinearActuatorManager[] linearActuatorManagers;

		public RotaryActuatorManager[] rotaryActuatorManagers;

		public SensorManager[] sensorManagers;

		public MagnetManager magnetManager;

		public void Awake() {
			for (int i = 0; i < this.linearActuatorManagers.Length; i++) {
				this.linearActuatorManagers[i].ID = i;
			}

			for (int i = 0; i < this.rotaryActuatorManagers.Length; i++) {
				this.rotaryActuatorManagers[i].ID = i;
			}

			for (int i = 0; i < this.sensorManagers.Length; i++) {
				this.sensorManagers[i].ID = i;
			}
		}

		public void Start() {

		}

		public void Update() {
			
		}

	}

}
