using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class WaitInstruction : Instruction {

		public WaitInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			int amt = (int)(float)await this.args[0].Execute(args);

			await Task.Delay(amt);
		}

	}
}
