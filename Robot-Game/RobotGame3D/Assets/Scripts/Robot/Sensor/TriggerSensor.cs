using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public abstract class TriggerSensor : Sensor {

		public event Action<float[]> onTrigger; 

		protected void Trigger() {
			this.onTrigger?.Invoke(this.GetData());
		}

	}

}
