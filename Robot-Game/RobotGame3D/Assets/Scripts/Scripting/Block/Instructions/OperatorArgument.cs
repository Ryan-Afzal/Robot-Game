using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public abstract class OperatorArgument : Argument {

		protected override string[] Text => new string[] { "", this.GetName(), "" };

		protected abstract string GetName();

	}
}
