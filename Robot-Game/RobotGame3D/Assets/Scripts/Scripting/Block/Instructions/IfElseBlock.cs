using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class IfElseBlock : Block {

		public override string[][] Text => new string[][] {
			new string[] { "If", "" },
			new string[] { "Else" },
			new string[] { "" }
		};

		protected override IInstruction Compile() {
			var instructions = new IInstruction[] { this.blockSockets[0].AttachedBlock?.GetCompiledInstruction(), this.blockSockets[1].AttachedBlock?.GetCompiledInstruction() };
			var args = new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() };

			return new IfElseInstruction(instructions, args);
		}

	}
}