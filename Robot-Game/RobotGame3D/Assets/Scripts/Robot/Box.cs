using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot {
	[RequireComponent(typeof(Rigidbody))]
	public class Box : MonoBehaviour {

		private Vector3 initialPos;
		private Quaternion initialRot;
		public Rigidbody Rb { get; private set; }

		public void Awake() {
			Rb = GetComponent<Rigidbody>();
			this.initialPos = transform.position;
			this.initialRot = transform.rotation;
		}

		public void Reset() {
			transform.position = this.initialPos;
			transform.rotation = this.initialRot;
		}

	}
}
