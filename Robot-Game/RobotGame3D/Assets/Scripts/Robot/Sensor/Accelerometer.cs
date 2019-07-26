﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public class Accelerometer : TriggerSensor {

		private readonly Rigidbody rb;

		public bool HasTriggerLimit { get; private set; }
		public float TriggerLimit { get; private set; }

		public Accelerometer() {
			HasTriggerLimit = false;
			TriggerLimit = 0.0f;

			this.rb = this.GetComponent<Rigidbody>();
		}

		public Accelerometer(float triggerLimit) : this() {
			HasTriggerLimit = true;
			TriggerLimit = triggerLimit;
		}

		protected override void Update() {
			if (rb.velocity.magnitude >= TriggerLimit) {
				this.Trigger();
			}
		}

		protected internal override float[] GetData() {
			return new float[] {
				this.rb.velocity.x, 
				this.rb.velocity.y, 
				this.rb.velocity.z
			};
		}
	}

}
