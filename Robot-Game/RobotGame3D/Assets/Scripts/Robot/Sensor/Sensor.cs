using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Sensor {

	public abstract class Sensor : MonoBehaviour {

		protected void Awake() {

		}

		protected void Start() {
			
		}

		protected void Update() {
			
		}

		protected internal abstract float[] GetData();

	}

}
