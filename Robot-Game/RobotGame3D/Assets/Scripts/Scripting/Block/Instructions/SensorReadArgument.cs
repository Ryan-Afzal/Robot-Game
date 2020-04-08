using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class SensorReadArgument : Argument {

		protected override string[] Text => new string[] { "Read Sensor #", "" };

		protected override IArgInstruction Compile() {
			return new ReadSensorArgInstruction(new IArgInstruction[] { this.argSockets[0].AttachedArgument.GetCompiledArgument() });
		}

	}
}
