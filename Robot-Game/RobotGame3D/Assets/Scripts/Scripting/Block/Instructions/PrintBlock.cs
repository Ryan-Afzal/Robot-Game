using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class PrintBlock : Block {

		public override string[][] Text => new string[][] {
			new string[] { "Print", "" }
		};

		protected override IInstruction Compile() {
			return new PrintInstruction(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() });
		}

	}
}
