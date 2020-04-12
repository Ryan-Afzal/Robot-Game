using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class AddOperator : Operator {

		public AddOperator(IArgInstruction[] args) : base(args) {

		}

		protected override object Operate(object[] objects) {
			return (float)objects[0] + (float)objects[1];
		}
	}
}
