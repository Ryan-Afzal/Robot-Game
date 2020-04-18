using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {
	
	public abstract class MotionManager : Manager {

		[HideInInspector]
		public LinkedList<Transform> children;

		public void AddChild(Transform t) {
			if (this.children is null) {
				this.children = new LinkedList<Transform>();
			}

			this.children.AddLast(t);
		}

		public override void Awake() {
			if (this.children is null) {
				this.children = new LinkedList<Transform>();
			}

			base.Awake();
		}
		
	}


}