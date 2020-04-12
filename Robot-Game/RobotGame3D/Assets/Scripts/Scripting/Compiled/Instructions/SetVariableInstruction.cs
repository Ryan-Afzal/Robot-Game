using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class SetVariableInstruction : Instruction {

		public SetVariableInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			args.Controller.Variables[(string)await this.args[0].Execute(args)] = await this.args[1].Execute(args);
		}

	}
}
