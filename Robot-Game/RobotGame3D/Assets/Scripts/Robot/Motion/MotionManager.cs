using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {
	
	[RequireComponent(typeof(ConfigurableJoint))]
	public abstract class MotionManager : Manager {

		protected ConfigurableJoint joint;

		public override void Awake() {
			this.joint = GetComponent<ConfigurableJoint>();
			base.Awake();
		}
		
	}


}