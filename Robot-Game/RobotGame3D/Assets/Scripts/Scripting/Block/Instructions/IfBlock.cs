using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class IfBlock : Block {

		public override string[][] Text => new string[][] {
			new string[] { "If", "" },
			new string[] { "" }
		};

		public override IInstruction Compile() {
			var instructions = new IInstruction[] { this.blockSockets[0].AttachedBlock.Compile() };
			var args = new IArgInstruction[] { this.argSockets[0].AttachedArgument.Compile() };

			var output = new IfInstruction(instructions, args);
			output.Next = this.GetNextBlock().Compile();
			output.Next.Previous = output;

			return output;
		}

	}
}
