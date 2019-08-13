using Assets.Scripts.Scripting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts {
	public class TestInstruction : StandaloneInstruction {

		protected override void Awake() {
			base.Awake();
			Name = "Test Instruction";
		}

		public override IEnumerator Execute(InstructionExecutionArgs args) {
			yield return null;
		}

	}
}
