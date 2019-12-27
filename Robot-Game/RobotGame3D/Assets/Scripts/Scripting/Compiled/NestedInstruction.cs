using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled {
	/// <summary>
	/// Base type for nested instructions, which have separate expression tree branches inside of them.
	/// </summary>
	public abstract class NestedInstruction : Instruction {

		/// <summary>
		/// The instructions nested inside.
		/// </summary>
		private readonly IInstruction[] instructions;

		protected NestedInstruction(IInstruction[] instructions, IArgInstruction[] args) : base(args) {
			this.instructions = instructions;
		}

		protected IInstruction this[int i] {
			get {
				return instructions[i];
			}
		}

		/// <summary>
		/// The number of different expression tree branches nested inside this instruction.
		/// </summary>
		public int Count {
			get {
				return this.instructions.Length;
			}
		}
	}
}
