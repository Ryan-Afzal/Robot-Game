using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public abstract class Instruction {

		protected struct Arg {
			public Instruction Instruction { get; set; }
			public Type Type { get; set; }
		}

		protected readonly Arg[] args;

		protected Instruction(Arg[] args) {
			this.args = args;
		}

		public abstract object Execute(InstructionExecutionArgs args);

		public abstract Type GetReturnType();

	}

}
