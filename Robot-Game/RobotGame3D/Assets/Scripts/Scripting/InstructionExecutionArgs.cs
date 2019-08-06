using Assets.Scripts.Robot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {

	public struct InstructionExecutionArgs {

		public InstructionExecutionArgs(RobotBase robotBase) {
			RobotBase = robotBase;
		}

		public RobotBase RobotBase { get; private set; }

	}

}
