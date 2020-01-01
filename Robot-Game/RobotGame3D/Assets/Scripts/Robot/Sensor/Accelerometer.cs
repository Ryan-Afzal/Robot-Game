using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public class Accelerometer : TriggerSensor {

		private readonly Rigidbody rb;

		public Accelerometer() {
			HasTriggerLimit = false;
			TriggerLimit = 0.0f;

			this.rb = this.GetComponent<Rigidbody>();
		}

		public Accelerometer(float triggerLimit) : this() {
			HasTriggerLimit = true;
			TriggerLimit = triggerLimit;
		}

		public bool HasTriggerLimit { get; }
		public float TriggerLimit { get; }

		protected override void Update() {
			if (rb.velocity.magnitude >= TriggerLimit) {
				this.Trigger();
			}
		}

		protected internal override object GetData() {
			return this.rb.velocity;
		}
	}

}
