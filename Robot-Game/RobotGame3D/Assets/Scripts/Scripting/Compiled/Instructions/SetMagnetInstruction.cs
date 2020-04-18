using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class SetMagnetInstruction : Instruction {

		public SetMagnetInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			var obj = await this.args[0].Execute(args);
			
			if ((bool)obj) {
				args.Robot.magnetManager.TurnOn();
			} else {
				args.Robot.magnetManager.TurnOff();
			}
		}
	}
}
