using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public class SensorManager : Manager {

		public Sensor sensor;

		protected override void InitConstraints() {	}

		public object GetData() {
			return this.sensor.GetData();
		}

	}
}
