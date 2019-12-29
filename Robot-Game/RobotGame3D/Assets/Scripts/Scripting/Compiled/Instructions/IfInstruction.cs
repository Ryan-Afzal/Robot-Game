using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class IfInstruction : NestedInstruction {

		public IfInstruction(IInstruction[] instructions, IArgInstruction[] args) : base(instructions, args) {

		}

		public override IEnumerable Execute(InstructionExecutionArgs args) {
			bool? test = null;
			foreach (var i in this.args[0].Execute<bool>(args, o => test = o)) {
				yield return null;
			}

			if (test.Value) {
				foreach (var result in InstructionUtils.ExecuteChain(this[0], args)) {
					yield return result;
				}
			}

			yield break;
		}
	}
}
