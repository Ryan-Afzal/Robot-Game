﻿using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class RotaryActuatorSetSpeedBlock : Block {
		public override string[][] Text => new string[][] {
			new string[] { "Set Actuator", "speed to", ""}
		};

		protected override IInstruction Compile() {
			return new RotaryActuatorSetSpeedInstruction(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument(), this.argSockets[1].AttachedArgument.GetCompiledArgument() });
		}
	}
}
