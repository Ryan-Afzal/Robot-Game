using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting {
	/// <summary>
	/// Base type for instructions.
	/// </summary>
	public interface IInstruction {

		/// <summary>
		/// The previous instruction in the expression tree.
		/// </summary>
		public IInstruction Previous { get; set; }

		/// <summary>
		/// The next instruction in the expression tree.
		/// </summary>
		public IInstruction Next { get; set; }

		/// <summary>
		/// Runs just before the instruction executes the first time.
		/// </summary>
		void Begin();

		/// <summary>
		/// Runs each update during execution. It returns whether the instruction has finished executing.
		/// </summary>
		/// <returns>Returns whether the instruction is finished executing.</returns>
		bool Update();

		/// <summary>
		/// Runs after the instruction is finished executing, when <c>Update()</c> returns <c>true</c>.
		/// </summary>
		void End();
	}
}