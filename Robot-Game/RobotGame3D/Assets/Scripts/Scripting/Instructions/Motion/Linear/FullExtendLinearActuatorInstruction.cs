using Assets.Scripts.Robot;
using Assets.Scripts.Robot.Motion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public sealed class FullExtendLinearActuatorInstruction : StandaloneInstruction {

		private LinearActuatorManager actuator;

		public FullExtendLinearActuatorInstruction(ArgInstruction[] args) : base(args) {
			if (!args[0].GetReturnType().Equals(typeof(int))) {
				throw new ArgumentException();
			}
		}

		protected override void BeginExecution(InstructionExecutionArgs args) {
			this.actuator = args.RobotBase.linearActuatorManagers[(int)this.args[0].Execute(args).Current];
			this.actuator.FullExtendActuator();
		}

		protected override bool IsExecutionFinished(InstructionExecutionArgs args) {
			return this.actuator.RelativePosition.magnitude > this.actuator.precisionTolerance;
		}
	}

}
