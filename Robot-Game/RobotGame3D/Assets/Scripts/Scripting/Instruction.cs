using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public struct InstructionExecutionArgs {

		public RobotBase RobotBase { get; set; }

	}

	public abstract class Instruction<T> {

		public Instruction() {

		}

		public abstract T Execute(InstructionExecutionArgs args);

	}

}