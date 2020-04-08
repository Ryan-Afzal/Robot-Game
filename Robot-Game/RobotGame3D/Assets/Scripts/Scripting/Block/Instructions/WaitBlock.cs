using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class WaitBlock : Block {
		public override string[][] Text => new string[][] {
			new string[] { "Wait", "milliseconds" }
		};

		protected override IInstruction Compile() {
			return new WaitInstruction(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() });
		}
	}
}
