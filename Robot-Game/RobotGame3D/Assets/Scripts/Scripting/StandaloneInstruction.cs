using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public abstract class StandaloneInstruction : Instruction {

		public abstract IEnumerator Execute(InstructionExecutionArgs args);

	}
}
