using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public sealed class FullExtendLinearActuatorInstruction : StandaloneInstruction {

		public FullExtendLinearActuatorInstruction(ArgInstruction[] args) : base(args) {
			if (!args[0].GetReturnType().Equals(typeof(int))) {
				throw new ArgumentException();
			}
		}

		protected override void BeginExecution(InstructionExecutionArgs args) {
			args.RobotBase.linearActuatorManagers[(int)this.args[0].Execute(args).Current].FullExtendActuator();
		}

		protected override bool IsExecutionFinished(InstructionExecutionArgs args) {
			throw new NotImplementedException();
		}
	}

}
