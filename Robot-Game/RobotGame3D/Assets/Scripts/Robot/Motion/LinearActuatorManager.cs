using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Robot.Motion {

	public class LinearActuatorManager : MotionManager {

		public float maxExtensionDistance;
		public float extensionSpeed;

		protected override void InitConstraints() {
			throw new NotImplementedException();
		}

		public bool ExtendActuatorTo(float distance) {
			throw new NotImplementedException();
		}

		public bool ExtendActuatorBy(float distance) {
			throw new NotImplementedException();
		}

	}
}
