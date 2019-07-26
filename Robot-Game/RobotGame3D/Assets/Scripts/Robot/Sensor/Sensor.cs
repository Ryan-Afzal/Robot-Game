using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public abstract class Sensor : MonoBehaviour {

		protected virtual void Awake() {

		}

		protected virtual void Start() {
			
		}

		protected virtual void Update() {
			
		}

		protected internal abstract float[] GetData();

	}

}
