using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public sealed class FullExtendLinearActuatorInstruction : StandaloneInstruction {

		public FullExtendLinearActuatorInstruction() : base(new Type[0], new ArgInstruction[0]) {

		}

		protected override void BeginExecution(InstructionExecutionArgs args) {
			throw new NotImplementedException();
		}

		protected override bool IsExecutionFinished(InstructionExecutionArgs args) {
			throw new NotImplementedException();
		}
	}

}
