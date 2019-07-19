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
		public Vector3 rotationAxes;

		protected override void InitConstraints() {
			this.joint.xMotion = ConfigurableJointMotion.Locked;
			this.joint.yMotion = ConfigurableJointMotion.Locked;
			this.joint.zMotion = ConfigurableJointMotion.Locked;
			this.joint.linearLimit = new SoftJointLimit() {
				limit = 0
			};

			this.joint.angularXMotion = this.hasRotationLimit ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free;
			this.joint.angularYMotion = this.hasRotationLimit ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free;
			this.joint.angularZMotion = this.hasRotationLimit ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Free;

			this.joint.autoConfigureConnectedAnchor = true;
			this.joint.rotationDriveMode = RotationDriveMode.Slerp;
			
			throw new NotImplementedException();
		}

		public bool RotateActuatorTo(float degrees) {
			throw new NotImplementedException();
		}

		public bool RotateActuatorBy(float degrees) {
			throw new NotImplementedException();
		}

	}
}
