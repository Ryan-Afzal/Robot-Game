using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Robot.Motion {
	
	public abstract class MotionManager<T> : Manager where T : Joint {

		public T joint;
		
	}


}