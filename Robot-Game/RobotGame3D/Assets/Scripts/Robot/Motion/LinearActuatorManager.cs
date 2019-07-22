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
		/// The axis of extension, relative to this component's <code>Transform</code>
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

		private void Update() {
			
		}

		protected override void InitConstraints() {
			if (this.hasExtensionLimit) {
				this.joint.linearLimit = new SoftJointLimit() { limit = this.extensionLimit };
			}
			
			this.joint.axis = this.axis;
			this.joint.xMotion = ConfigurableJointMotion.Limited;
			this.joint.yMotion = ConfigurableJointMotion.Limited;
			this.joint.zMotion = ConfigurableJointMotion.Limited;
			this.joint.angularXMotion = ConfigurableJointMotion.Locked;
			this.joint.angularYMotion = ConfigurableJointMotion.Locked;
			this.joint.angularZMotion = ConfigurableJointMotion.Locked;
			this.joint.targetPosition = Vector3.zero;
			this.joint.targetVelocity = this.extensionSpeed * this.axis;

			JointDrive drive = new JointDrive() {
				positionSpring = this.extensionSpeed,
				maximumForce = this.extensionSpeed
			};
			this.joint.xDrive = drive;
			this.joint.yDrive = drive;
			this.joint.zDrive = drive;
		}

		public bool ExtendActuatorTo(float distance) {
			this.joint.targetPosition = this.joint.axis * distance;
			//this.joint.targetVelocity = this.extensionSpeed * this.axis;
			return true;
		}

		public bool ExtendActuatorBy(float distance) {
			this.joint.targetPosition += (this.axis * distance);
			//this.joint.targetVelocity = this.extensionSpeed * this.axis;
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
