using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public sealed class InstructionSet {

		private readonly StandaloneInstruction root;

		public InstructionSet(StandaloneInstruction root) {
			this.root = root;
		}

		public bool IsRunning { get; private set; }

		public IEnumerator ExecuteInstructions(InstructionExecutionArgs args) {
			if (IsRunning) {
				yield break;
			}

			IsRunning = true;

			StandaloneInstruction instruction = this.root;
			while (instruction != null) {
				yield return instruction.Execute(args);
				instruction = instruction.Next;
			}

			IsRunning = false;
		}

	}

}
