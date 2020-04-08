using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public sealed class NotOperatorArgument : Argument {
		protected override string[] Text => new string[] { "!", "" };

		protected override IArgInstruction Compile() {
			return new NotOperator(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() });
		}
	}
}
