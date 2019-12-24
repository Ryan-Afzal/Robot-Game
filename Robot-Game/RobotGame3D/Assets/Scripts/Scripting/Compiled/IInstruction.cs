using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting.Compiled {
	/// <summary>
	/// Base type for instructions.
	/// </summary>
	public interface IInstruction {

		/// <summary>
		/// The previous instruction in the expression tree.
		/// </summary>
		IInstruction Previous { get; set; }

		/// <summary>
		/// The next instruction in the expression tree.
		/// </summary>
		IInstruction Next { get; set; }

		/// <summary>
		/// Calls when the instruction executes.
		/// Called as part of a coroutine.
		/// </summary>
		/// <returns>Returns an IEnumerable specifying that it is not finished executing.</returns>
		IEnumerable Execute();
	}
}