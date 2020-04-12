using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot {

	/// <summary>
	/// Makes the attached component available to the <c>RobotBase</c> and provides the interface for interaction.
	/// </summary>
	public abstract class Manager : MonoBehaviour {

		public RobotBase robotBase;
		
		public virtual void Awake() {
			this.InitConstraints();
		}

		public int ID { get; internal set; }

		protected abstract void InitConstraints();

	}

}
