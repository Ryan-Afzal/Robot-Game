using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {
	public class AngleSensor : Sensor {

		private Rigidbody rb;

		protected override void Awake() {
			base.Awake();
			this.rb = GetComponent<Rigidbody>();
		}

		protected internal override object GetData() {
			return this.rb.rotation;
		}
	}
}
