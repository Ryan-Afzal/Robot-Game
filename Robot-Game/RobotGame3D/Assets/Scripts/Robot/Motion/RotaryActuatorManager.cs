using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class RotaryActuatorManager : MotionManager<ConfigurableJoint> {

		/// <summary>
		/// The axes of the angle of rotation, relative to this component's <code>Transform</code>
		/// </summary>
		public Vector3 axis;

		/// <summary>
		/// Determines whether there is a limit to how far the actuator can rotate.
		/// </summary>
		public bool hasRotationLimit;

		/// <summary>
		/// The max rotation limit, in degrees.
		/// </summary>
		public float rotationMaxLimit;

		/// <summary>
		/// The min rotation limit, in degrees.
		/// </summary>
		public float rotationMinLimit;

		/// <summary>
		/// The speed of rotation when rotating to a specific angle.
		/// </summary>
		public float rotationSpeed;

		protected override void InitConstraints() {
			this.joint.axis = this.axis;
			this.joint.xMotion = ConfigurableJointMotion.Locked;
			this.joint.yMotion = ConfigurableJointMotion.Locked;
			this.joint.zMotion = ConfigurableJointMotion.Locked;
			this.joint.angularXMotion = ConfigurableJointMotion.Locked;
			this.joint.angularYMotion = ConfigurableJointMotion.Locked;
			this.joint.angularZMotion = ConfigurableJointMotion.Locked;

			//Set rotation drive mode
		}

		public bool SetActuatorSpeed(float speed) {
			this.joint.targetAngularVelocity = this.axis * speed;
			return true;
		}

		public bool RotateActuatorTo(float angleInDegrees) {
			this.joint.targetRotation = this.GetRotationFromAngle(angleInDegrees);
			return true;
		}

		public bool RotateActuatorBy(float angleInDegrees) {
			this.joint.targetRotation *= this.GetRotationFromAngle(angleInDegrees);
			return true;
		}

		private Quaternion GetRotationFromAngle(float angleInDegrees) {
			return Quaternion.Euler(
				this.axis.x * angleInDegrees, 
				this.axis.y * angleInDegrees, 
				this.axis.z * angleInDegrees);
		}

	}
}
