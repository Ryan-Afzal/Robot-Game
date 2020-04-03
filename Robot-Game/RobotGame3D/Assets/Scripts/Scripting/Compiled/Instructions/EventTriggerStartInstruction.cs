using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class EventTriggerStartInstruction : Instruction {

		public EventTriggerStartInstruction() : base(new IArgInstruction[0]) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			// Do Nothing
		}

	}
}
