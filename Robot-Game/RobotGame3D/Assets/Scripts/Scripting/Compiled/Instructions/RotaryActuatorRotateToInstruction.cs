﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class RotaryActuatorRotateToInstruction : Instruction {

		public RotaryActuatorRotateToInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			int actuatorID = (int)(float)await this.args[0].Execute(args);
			float setpoint = (float)await this.args[1].Execute(args);

			args.Robot.rotaryActuatorManagers[actuatorID].RotateActuatorTo(setpoint);
		}
	}
}
