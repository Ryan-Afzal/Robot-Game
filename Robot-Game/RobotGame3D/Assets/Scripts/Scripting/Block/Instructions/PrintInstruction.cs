using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class PrintInstruction : BlockInstruction {

		public override void Start() {
			base.Start();
			this.startText = "Print (\"Printed\")";
		}

		public override IInstruction GetCompiledInstruction() {
			var output = new Compiled.Instructions.PrintInstruction(new IArgInstruction[0]);
			IInstruction next = Next?.GetCompiledInstruction();

			output.Next = next;

			if (next is object) {
				next.Previous = output;
			}

			return output;
		}
	}
}
