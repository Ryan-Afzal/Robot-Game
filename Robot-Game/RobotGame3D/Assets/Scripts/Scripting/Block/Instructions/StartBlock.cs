using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public sealed class StartBlock : EventTriggerBlock {

		public override string GetName() {
			return "Start";
		}

	}
}
