using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class RotaryActuatorManager : MotionManager {

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
			this.joint.angularXMotion = ConfigurableJointMotion.Free;
			this.joint.angularYMotion = ConfigurableJointMotion.Locked;
			this.joint.angularZMotion = ConfigurableJointMotion.Locked;
			this.joint.rotationDriveMode = RotationDriveMode.XYAndZ;

			this.joint.angularYZLimitSpring = new SoftJointLimitSpring() { spring = 1, damper = 1 };
		}

		public bool SetActuatorSpeed(float speed) {
			this.joint.targetAngularVelocity = new Vector3(speed, 0, 0);
			float d = Mathf.Abs(this.joint.targetAngularVelocity.x - GetComponent<Rigidbody>().angularVelocity.x);
			this.joint.angularXDrive = new JointDrive() {
				positionSpring = d,
				positionDamper = d,
				maximumForce = d * 2
			};
			return true;
		}

		public bool IncreaseActuatorSpeedBy(float speed) {
			this.joint.targetAngularVelocity += new Vector3(speed, 0, 0);
			this.joint.angularXDrive = new JointDrive() {
				positionSpring = this.joint.angularXDrive.positionSpring + speed,
				positionDamper = this.joint.angularXDrive.positionDamper + speed,
				maximumForce = this.joint.angularXDrive.maximumForce + speed * 2
			};
			return true;
		}

		public Vector3 GetActuatorSpeed() {
			return this.joint.targetAngularVelocity;
		}

		public bool RotateActuatorTo(float angleInDegrees) {
			this.joint.targetRotation = this.GetRotationFromAngle(angleInDegrees);
			this.joint.angularXDrive = new JointDrive() {
				positionSpring = this.rotationSpeed,
				positionDamper = this.rotationSpeed,
				maximumForce = this.rotationSpeed * 2
			};
			return true;
		}

		public bool RotateActuatorBy(float angleInDegrees) {
			this.joint.targetRotation *= this.GetRotationFromAngle(angleInDegrees);
			this.joint.angularXDrive = new JointDrive() {
				positionSpring = this.rotationSpeed,
				positionDamper = this.rotationSpeed,
				maximumForce = this.rotationSpeed * 2
			};
			return true;
		}

		private Quaternion GetRotationFromAngle(float angleInDegrees) {
			return Quaternion.Euler(angleInDegrees, 0.0f, 0.0f);
		}

	}
}
