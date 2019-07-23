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

		protected override void InitConstraints() {
			if (this.hasExtensionLimit) {
				this.joint.linearLimit = new SoftJointLimit() { limit = this.extensionLimit };
			}

			this.joint.axis = this.axis;
			this.joint.xMotion = ConfigurableJointMotion.Limited;
			this.joint.yMotion = ConfigurableJointMotion.Locked;
			this.joint.zMotion = ConfigurableJointMotion.Locked;
			this.joint.angularXMotion = ConfigurableJointMotion.Locked;
			this.joint.angularYMotion = ConfigurableJointMotion.Locked;
			this.joint.angularZMotion = ConfigurableJointMotion.Locked;
			this.joint.targetPosition = Vector3.zero;

			JointDrive drive = new JointDrive() {
				positionSpring = this.extensionSpeed,
				positionDamper = this.extensionSpeed,
				maximumForce = this.extensionSpeed * 2
			};
			this.joint.xDrive = drive;
			this.joint.yDrive = drive;
			this.joint.zDrive = drive;
		}

		public bool ExtendActuatorTo(float distance) {
			this.joint.targetPosition = new Vector3(1, 0, 0) * distance;
			return true;
		}

		public bool ExtendActuatorBy(float distance) {
			this.joint.targetPosition += new Vector3(1, 0, 0) * distance;
			return true;
		}

		public bool FullExtendActuator() {
			return this.ExtendActuatorTo(this.extensionLimit);
		}

		public bool FullRetractActuator() {
			return this.ExtendActuatorTo(0.0f);
		}

	}
}
