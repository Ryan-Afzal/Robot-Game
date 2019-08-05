using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public abstract class StandaloneInstruction : Instruction {
		
		protected StandaloneInstruction(ArgInstruction[] args) : base(args) {

		}

		protected StandaloneInstruction() : this(new ArgInstruction[0]) { }

		public StandaloneInstruction Next { get; private set; }

		protected void Attach(StandaloneInstruction instruction) {
			if (Next == null) {
				Next = instruction;
			} else {
				throw new NotSupportedException("An instruction is already connected to this instruction.");
			}
		}

		public override IEnumerator<object> Execute(InstructionExecutionArgs args) {
			this.BeginExecution(args);
			
			while (!this.IsExecutionFinished(args)) {
				yield return null;
			}
			
			yield break;
		}

		protected abstract void BeginExecution(InstructionExecutionArgs args);

		protected abstract bool IsExecutionFinished(InstructionExecutionArgs args);

	}

}
