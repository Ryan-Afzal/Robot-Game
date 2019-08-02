using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public abstract class StandaloneInstruction : Instruction {
		
		protected StandaloneInstruction(Type[] argTypes, ArgInstruction[] args) : base(argTypes, args) { }

		public override IEnumerator<object> Execute(InstructionExecutionArgs args) {
			this.BeginExecution(args);
			
			while (!this.IsExecutionFinished(args)) {
				yield return null;
			}
			
			yield return true;
		}

		protected abstract void BeginExecution(InstructionExecutionArgs args);

		protected abstract bool IsExecutionFinished(InstructionExecutionArgs args);

	}

}
