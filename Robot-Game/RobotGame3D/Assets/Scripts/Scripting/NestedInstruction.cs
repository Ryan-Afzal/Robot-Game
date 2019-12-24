using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {
	/// <summary>
	/// Base type for nested instructions, which have separate expression tree branches inside of them.
	/// </summary>
	public abstract class NestedInstruction : IInstruction {

		/// <summary>
		/// The instructions nested inside.
		/// </summary>
		private readonly IInstruction[] instructions;

		public NestedInstruction(IInstruction[] instructions) {
			this.instructions = instructions;
		}

		public IInstruction this[int i] {
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

		public abstract IInstruction Previous { get; set; }
		public abstract IInstruction Next { get; set; }

		public abstract void Begin();

		public abstract bool Update();

		public abstract void End();
	}
}
