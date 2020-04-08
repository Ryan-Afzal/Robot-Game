using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	/// <summary>
	/// Simple loop. Repeat [arg0] times.
	/// </summary>
	public sealed class RepeatInstruction : NestedInstruction {

		public RepeatInstruction(IInstruction[] instructions, IArgInstruction[] args) : base(instructions, args) {

		}

		public override async Task Execute(InstructionExecutionArgs args) {
			int test = (int)((float)(await this.args[0].Execute(args)));

			for (int i = 0; i < test; i++) {
				await this[0]?.ExecuteChainAsync(args);
			}
		}
	}
}
