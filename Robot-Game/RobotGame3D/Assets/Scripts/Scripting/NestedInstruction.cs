using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public abstract class NestedInstructionInstruction : StandaloneInstruction {

		public int numInstructions;

		private StandaloneInstruction[] instructions;

		protected override void Awake() {
			base.Awake();

			this.instructions = new StandaloneInstruction[this.numInstructions];
		}

	}
}
