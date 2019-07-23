using Assets.Scripts.Robot.Motion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot {

	public class RobotBase : MonoBehaviour {

		public Manager[] managers;

		private void Awake() {
			
		}

		private void Start() {
			
		}

		private void Update() {
			
		}

		public int AddManager(Manager manager) {
			if (manager is LinearActuatorManager linearActuatorManager) {
				throw new NotImplementedException();
			} else if (manager is RotaryActuatorManager rotaryActuatorManager) {
				throw new NotImplementedException();
			} else if (manager is SensorManager sensorManager) {
				throw new NotImplementedException();
			}

			throw new NotImplementedException();
		}

		private int AddLinearActuatorManager(int managerID, LinearActuatorManager manager) {
			throw new NotImplementedException();
		}

		private int AddRotaryActuatorManager(int managerID, RotaryActuatorManager manager) {
			throw new NotImplementedException();
		}

		private int AddSensorManager(int managerID, SensorManager manager) {
			throw new NotImplementedException();
		}

	}

}