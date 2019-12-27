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

		public override IEnumerable Execute() {
			bool? test = null;
			foreach (var i in this.args[0].Execute<bool>(o => test = o)) {
				yield return null;
			}

			if (test.Value) {
				foreach (var result in this[0].Execute()) {
					yield return result;
				}
			}

			yield break;
		}
	}
}
