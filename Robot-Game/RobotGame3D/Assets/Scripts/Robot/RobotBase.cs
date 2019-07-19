﻿using Assets.Scripts.Robot.Motion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot {

	public class RobotBase : MonoBehaviour {

		public Manager[] managers;

		private void Awake() {
			if (this.managers == null) {
				this.managers = new Manager[0];
			}
		}

		private void Start() {
			foreach (Manager manager in this.managers) {
				this.AddManager(manager);
			}
		}

		private void Update() {
			
		}

		public int AddManager(Manager manager) {
			if (manager is MotionManager) {
				if (manager is LinearActuatorManager linearActuatorManager) {
					throw new NotImplementedException();
				} else if (manager is RotaryActuatorManager rotaryActuatorManager) {
					throw new NotImplementedException();
				} else {
					return -1;
				}
			} else {
				throw new NotImplementedException();
			}
		}

		private int AddLinearActuatorManager(int managerID, LinearActuatorManager manager) {
			throw new NotImplementedException();
		}

		private int AddRotaryActuatorManager(int managerID, RotaryActuatorManager manager) {
			throw new NotImplementedException();
		}

	}

}