using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {

	public abstract class ArgInstruction : Instruction {

		protected ArgInstruction(ArgInstruction[] args) : base(args) { }

		public override IEnumerator<object> Execute(InstructionExecutionArgs args) {
			yield return this.GetValue(args);
		}

		protected abstract object GetValue(InstructionExecutionArgs args);

		public abstract Type GetReturnType();

	}

}
