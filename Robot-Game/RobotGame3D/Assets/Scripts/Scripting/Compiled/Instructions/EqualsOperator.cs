using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class EqualsOperator : Operator {

		public EqualsOperator(IArgInstruction[] args) : base(args) {

		}

		protected override object Operate(object[] objects) {
			return objects[0].Equals(objects[1]);
		}
	}
}
