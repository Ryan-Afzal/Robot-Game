using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class RotaryActuatorSetSpeedInstruction : Instruction {

		public RotaryActuatorSetSpeedInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			int actuatorID = (int)await this.args[0].Execute(args);
			float speed = (float)await this.args[1].Execute(args);

			args.Robot.rotaryActuatorManagers[actuatorID].SetActuatorSpeed(speed);
		}
	}
}
