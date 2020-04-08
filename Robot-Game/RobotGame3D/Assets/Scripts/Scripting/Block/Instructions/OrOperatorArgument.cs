﻿using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public sealed class OrOperatorArgument : OperatorArgument {
		protected override IArgInstruction Compile() {
			return new OrOperator(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument(), this.argSockets[1].AttachedArgument.GetCompiledArgument() });
		}

		protected override string GetName() {
			return "OR";
		}
	}
}
