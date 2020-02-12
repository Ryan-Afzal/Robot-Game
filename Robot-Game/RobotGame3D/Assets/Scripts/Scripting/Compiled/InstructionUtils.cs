using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {
	public static class InstructionExtensions {

		/// <summary>
		/// Executes the provided <c>IInstruction</c> and all of its following instructions in order, asynchronously.
		/// </summary>
		/// <param name="instruction"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static async Task ExecuteChainAsync(this IInstruction instruction, InstructionExecutionArgs args) {
			var i = instruction;
			while (i is object) {
				await i.Execute(args);
				i = i.Next;
			}
		}

	}
}
