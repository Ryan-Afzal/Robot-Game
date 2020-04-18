using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {
	[RequireComponent(typeof(RotaryActuatorManager))]
	public class AngleSensor : Sensor {

		private RotaryActuatorManager rotaryActuatorManager;

		protected override void Awake() {
			base.Awake();
			this.rotaryActuatorManager = GetComponent<RotaryActuatorManager>();

		}

		protected internal override object GetData() {
			float angle = this.rotaryActuatorManager.DeltaAngle;
			//return (angle / Mathf.Abs(angle)) * Quaternion.Angle(transform.rotation, this.rotaryActuatorManager.parent?.transform.rotation ?? Quaternion.identity);
			return angle % 360;
		}
	}
}
