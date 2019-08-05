using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public abstract class Instruction {

		protected readonly ArgInstruction[] args;

		protected Instruction(ArgInstruction[] args) {
			this.args = args;
		}

		public abstract IEnumerator<object> Execute(InstructionExecutionArgs args);

	}

}
