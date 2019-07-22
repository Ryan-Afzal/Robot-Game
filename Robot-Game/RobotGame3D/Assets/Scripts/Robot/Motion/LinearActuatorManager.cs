using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class LinearActuatorManager : MotionManager<ConfigurableJoint> {

		/// <summary>
		/// The axis to extend on.
		/// </summary>
		public Vector3 axis;

		/// <summary>
		/// The maximum linear distance from the origin point.
		/// </summary>
		public float extensionLimit;

		protected override void InitConstraints() {
			this.joint.linearLimit = new SoftJointLimit() { limit = this.extensionLimit };
			this.joint.axis = this.axis;
			this.joint.xMotion = ConfigurableJointMotion.Limited;
			this.joint.yMotion = ConfigurableJointMotion.Limited;
			this.joint.zMotion = ConfigurableJointMotion.Limited;
			this.joint.targetPosition = Vector3.zero;
		}

		public bool ExtendActuatorTo(float distance) {
			this.joint.targetPosition = this.joint.axis * distance;
			return true;
		}

		public bool ExtendActuatorBy(float distance) {
			this.joint.targetPosition += (this.axis * distance);
			return true;
		}

		public bool FullExtendActuator() {
			this.joint.targetPosition = this.joint.axis * this.extensionLimit;
			return true;
		}

		public bool FullRetractActuator() {
			this.joint.targetPosition = Vector3.zero;
			return true;
		}

	}
}
