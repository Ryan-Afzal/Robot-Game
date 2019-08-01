using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Scripting {

	public abstract class Instruction {

		protected readonly Type[] argTypes;
		protected readonly ArgInstruction[] args;

		protected Instruction(Type[] argTypes, ArgInstruction[] args) {
			this.argTypes = argTypes;
			this.args = args;

			if (this.argTypes.Length != this.args.Length) {
				throw new ArgumentException();
			} else {
				for (int i = 0; i < this.args.Length; i++) {
					if (!this.args[i].GetReturnType().Equals(this.argTypes[i])) {
						throw new ArgumentException();
					}
				}
			}
		}

		public abstract IEnumerator<object> Execute(InstructionExecutionArgs args);

		public abstract Type GetReturnType();

	}

}
