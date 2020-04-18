using Assets.Scripts.Robot.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {

	public class RotaryActuatorManager : MotionManager {

		private Vector3 initialPos;
		private Quaternion initialRot;

		public MotionManager parent;

		public Vector3 relativeAnchorPosition;

		public int axis;

		private float speed;

		public float DeltaAngle { get; private set; }

		protected override void InitConstraints() {
			this.speed = 0.0f;
			this.parent?.AddChild(transform);
			this.initialPos = transform.position;
			this.initialRot = transform.rotation;
			DeltaAngle = 0.0f;
		}

		public void Update() {
			float angle = this.speed * Time.deltaTime;

			this.Rotate(transform.TransformPoint(this.relativeAnchorPosition), this.GetAxis(), angle);
		}

		private void Rotate(Vector3 point, Vector3 axis, float angle) {
			foreach (var t in this.children) {
				if (t.TryGetComponent(out RotaryActuatorManager r)) {
					r.Rotate(point, axis, angle);
				} else {
					t.RotateAround(point, axis, angle);
				}
			}

			var prevRot = transform.rotation;

			transform.RotateAround(point, axis, angle);

			DeltaAngle += (angle / Mathf.Abs(angle)) * Quaternion.Angle(transform.rotation, prevRot);
		}

		private Vector3 GetAxis() {// 0=x, 1=y, 2=z
			if (this.axis == 0) {
				return transform.right;
			} else if (this.axis == 1) {
				return transform.up;
			} else {
				return transform.forward;
			}
		}

		public bool SetActuatorSpeed(float speed) {
			this.speed = speed;
			return true;
		}

		public bool RotateActuatorTo(float angleInDegrees) {
			throw new NotImplementedException();
		}

		public void Reset() {
			this.speed = 0;
			transform.position = this.initialPos;
			transform.rotation = this.initialRot;
			DeltaAngle = 0.0f;
		}

	}
}
