using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public struct InstructionExecutionArgs {

	}

	public abstract class Instruction {

		public Instruction() {

		}

		public abstract void Execute(InstructionExecutionArgs args);

	}

}