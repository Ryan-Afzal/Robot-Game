using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class LinearActuatorManager : MotionManager {

		/// <summary>
		/// The axis of extension.
		/// </summary>
		public Vector3 axis;

		/// <summary>
		/// Determines whether there is a limit to how far the actuator can extend.
		/// </summary>
		public bool hasExtensionLimit;

		/// <summary>
		/// The maximum linear distance from the origin point.
		/// </summary>
		public float extensionLimit;

		/// <summary>
		/// The speed at which the actuator extends.
		/// </summary>
		public float extensionSpeed;

		/// <summary>
		/// The level of precision before a movement can be considered complete.
		/// </summary>
		public float precisionTolerance;

		protected override void InitConstraints() {
			throw new NotImplementedException();
		}

		public bool ExtendActuatorTo(float distance) {
			throw new NotImplementedException();
		}

		public bool ExtendActuatorBy(float distance) {
			throw new NotImplementedException();
		}

		public bool FullExtendActuator() {
			return this.ExtendActuatorTo(this.extensionLimit);
		}

		public bool FullRetractActuator() {
			return this.ExtendActuatorTo(0.0f);
		}

	}
}
