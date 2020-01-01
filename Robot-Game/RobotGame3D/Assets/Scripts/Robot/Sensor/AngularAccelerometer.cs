using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public class AngularAccelerometer : Sensor {

		private readonly Rigidbody rb;

		public AngularAccelerometer() {
			this.rb = this.GetComponent<Rigidbody>();
		}

		protected internal override object GetData() {
			return this.rb.angularVelocity;
		}
	}

}
