using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public class PrintInstruction : Instruction {

		public PrintInstruction(IArgInstruction[] args) : base(args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			await Task.Run(Print);
		}

		private void Print() {
			Debug.Log("Printed");
		}
	}
}
