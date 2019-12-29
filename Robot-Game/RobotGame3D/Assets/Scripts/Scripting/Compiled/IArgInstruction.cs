using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled {
	/// <summary>
	/// Base type for instruction arguments. Its <c>Execute()</c> method returns a value.
	/// </summary>
	public interface IArgInstruction {

		/// <summary>
		/// Executes the <c>IArgInstruction</c> and returns the result.
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		Task<object> Execute(InstructionExecutionArgs args);

	}
}
