using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public class InstructionSet {

		private readonly Instruction[] instructions;

		public InstructionSet(Instruction[] instructions, bool canMultiRun) {
			this.instructions = instructions;
			CanMultiRun = canMultiRun;
		}

		public int NumInstructions {
			get {
				return this.instructions.Length;
			}
		}

		public bool CanMultiRun { get; private set; }
		public bool IsRunning { get; private set; }

		public IEnumerator ExecuteInstructions(InstructionExecutionArgs args) {
			if (!CanMultiRun) {
				IsRunning = true;
			}

			for (int i = 0; i < NumInstructions; i++) {
				this.instructions[i].Execute(args);
				yield return null;
			}

			IsRunning = false;
		}

	}

}
