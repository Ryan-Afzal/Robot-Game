using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class WhileLoopInstruction : NestedInstruction {

		public WhileLoopInstruction(IInstruction[] instructions, IArgInstruction[] args) : base(instructions, args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			while ((bool)await this.args[0].Execute(args)) {
				await this[0]?.ExecuteChainAsync(args);
			}
		}

	}
}
