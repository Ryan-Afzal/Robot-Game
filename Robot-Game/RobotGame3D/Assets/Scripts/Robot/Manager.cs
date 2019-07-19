using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Robot {

	/// <summary>
	/// Makes the attached component available to the <code>RobotBase</code> and provides the interface for interaction.
	/// </summary>
	public abstract class Manager : MonoBehaviour {

		public RobotBase robotBase;
		
		private void Awake() {
			ID = this.robotBase.AddManager(this);
			this.InitConstraints();
		}

		public int ID { get; private set; }

		protected abstract void InitConstraints();

	}

}
