using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class LiteralBoolArgInstruction : IArgInstruction {

		private readonly bool value;

		public LiteralBoolArgInstruction(bool value) {
			this.value = value;
		}

		public async Task<object> Execute(InstructionExecutionArgs args) {
			return await Task.FromResult(this.value as object);
		}
	}
}
