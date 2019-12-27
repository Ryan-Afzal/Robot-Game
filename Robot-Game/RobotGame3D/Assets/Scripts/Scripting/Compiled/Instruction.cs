using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled {
	public abstract class Instruction : IInstruction {

		protected readonly IArgInstruction[] args;

		protected Instruction(IArgInstruction[] args) {
			this.args = args;
		}

		public IInstruction Previous { get; set; }
		public IInstruction Next { get; set; }

		public abstract IEnumerable Execute();
	}
}
