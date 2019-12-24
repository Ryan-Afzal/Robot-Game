using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Compiled {
	/// <summary>
	/// Base type for instruction arguments. Its <c>End()</c> method returns a value.
	/// </summary>
	public interface IArgInstruction {

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
		/// It should return a value.
		/// </summary>
		object End();

	}
}
