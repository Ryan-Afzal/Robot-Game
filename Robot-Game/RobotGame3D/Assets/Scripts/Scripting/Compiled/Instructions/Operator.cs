using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public abstract class Operator : NestedArgInstruction {

		public Operator(IArgInstruction[] args) : base(args) {

		}

		public override async Task<object> Execute(InstructionExecutionArgs args) {
			var arr = new object[this.args.Length];

			for (int i = 0; i < arr.Length; i++) {
				arr[i] = await this.args[i].Execute(args);
			}

			return this.Operate(arr);
		}

		protected abstract object Operate(object[] objects);

	}
}
