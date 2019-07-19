using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class RotaryActuatorManager : MotionManager<HingeJoint> {

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
		/// The maximum rotation speed.
		/// </summary>
		public float maxRotationSpeed;

		/// <summary>
		/// The axes of the angle of rotation, relative to this component's <code>Transform</code>
		/// </summary>
		public Vector3 axis;

		protected override void InitConstraints() {
			this.joint.axis = axis;
			this.joint.useLimits = this.hasRotationLimit;
			this.joint.limits = new JointLimits() {
				max = this.rotationMaxLimit, 
				min = this.rotationMinLimit
			};
			this.joint.useMotor = true;
			this.joint.motor = new JointMotor() {
				force = 0, 
				freeSpin = false, 
				targetVelocity = 0
			};
		}

		public void SetActuatorSpeed(float speed) {
			this.joint.motor = new JointMotor() {
				force = speed,
				freeSpin = false,
				targetVelocity = speed
			};
		}

	}
}
