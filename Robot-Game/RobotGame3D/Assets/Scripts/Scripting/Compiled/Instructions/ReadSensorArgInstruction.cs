using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class ReadSensorArgInstruction : NestedArgInstruction {

		public ReadSensorArgInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task<object> Execute(InstructionExecutionArgs args) {
			int test = (int)await this.args[0].Execute(args);

			return args.Robot.sensorManagers[test].GetData();
		}

	}
}
