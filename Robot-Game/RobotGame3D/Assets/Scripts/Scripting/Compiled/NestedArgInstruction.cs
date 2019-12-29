using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled {
	public abstract class NestedArgInstruction : IArgInstruction {

		protected readonly IArgInstruction[] args;

		protected NestedArgInstruction(IArgInstruction[] args) {
			this.args = args;
		}

		public abstract void Begin(InstructionExecutionArgs args);
		public abstract object End(InstructionExecutionArgs args);
		public abstract bool Update(InstructionExecutionArgs args);
	}
}
