using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
		/// Called to execute the instruction asynchronously.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		Task Execute(InstructionExecutionArgs args);
	}
}