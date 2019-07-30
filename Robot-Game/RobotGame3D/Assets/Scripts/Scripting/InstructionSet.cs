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

		public InstructionSet(Instruction[] instructions) {
			this.instructions = instructions;
		}

		public int NumInstructions {
			get {
				return this.instructions.Length;
			}
		}

		public IEnumerator ExecuteInstructions(InstructionExecutionArgs args) {
			for (int i = 0; i < NumInstructions; i++) {
				this.instructions[i].Execute(args);
				yield return null;
			}
		}

	}

}
