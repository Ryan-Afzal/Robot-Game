using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class MagnetBlock : Block {

		public override string[][] Text => new string[][] {
			new string[] { "Set Magnet", "" }
		};

		protected override IInstruction Compile() {
			return new SetMagnetInstruction(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() });
		}

	}
}
