using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class WaitUntilInstruction : Instruction {

		public WaitUntilInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			bool test;
			do {
				await Task.Yield();
				test = (bool)await this.args[0].Execute(args);
			} while (!test);
		}

	}
}
