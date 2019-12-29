using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class ReadSensorArgInstruction : NestedArgInstruction {

		public ReadSensorArgInstruction(IArgInstruction[] args) : base(args) {

		}

		public override void Begin(InstructionExecutionArgs args) {

		}

		public override bool Update(InstructionExecutionArgs args) {
			return true;
		}

		public override object End(InstructionExecutionArgs args) {
			throw new NotImplementedException();
		}
	}
}
