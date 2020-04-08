using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled.Instructions {
	public sealed class NotOperator : Operator {

		public NotOperator(IArgInstruction[] args) : base(args) {

		}

		protected override object Operate(object[] objects) {
			return !(bool)objects[0];
		}
	}
}
