using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {
	public class MagnetManager : MotionManager {

		private Vector3 initialPos;
		private Quaternion initialRot;

		public MotionManager parent;

		public float threshold;

		private bool isOn;

		private Box box;

		protected override void InitConstraints() {
			this.parent?.AddChild(transform);
			this.isOn = false;
			this.box = null;
			this.initialPos = transform.position;
			this.initialRot = transform.rotation;
		}

		public void Update() {
			if (this.isOn) {
				if (this.box is null) {
					var boxObj = GameObject.FindGameObjectWithTag("Box");
					if (Vector3.Distance(transform.position, boxObj.transform.position) < this.threshold) {
						this.box = boxObj.GetComponent<Box>();
						this.box.Rb.useGravity = false;
					}
				} else {
					this.box.transform.position = transform.position;
				}
			} else {
				if (this.box is object) {
					this.box.Rb.useGravity = true;
					this.box = null;
				}
			}
		}

		public void TurnOn() {
			this.isOn = true;
		}

		public void TurnOff() {
			this.isOn = false;
		}

		public void Reset() {
			if (this.box is object) {
				this.box.Rb.useGravity = true;
				this.box = null;
			}

			this.TurnOff();
			transform.position = this.initialPos;
			transform.rotation = this.initialRot;
		}
	}
}
