using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class IfElseInstruction : NestedInstruction {

		public IfElseInstruction(IInstruction[] instructions, IArgInstruction[] args) : base(instructions, args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			bool test = (bool)await this.args[0].Execute(args);

			if (test) {
				await this[0].ExecuteChainAsync(args);
			} else {
				await this[1].ExecuteChainAsync(args);
			}
		}

	}
}
