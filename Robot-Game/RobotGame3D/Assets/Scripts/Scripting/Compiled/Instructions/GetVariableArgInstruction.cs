using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class GetVariableArgInstruction : NestedArgInstruction {

		public GetVariableArgInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task<object> Execute(InstructionExecutionArgs args) {
			return args.Controller.Variables[(string)await this.args[0].Execute(args)];
		}

	}
}
