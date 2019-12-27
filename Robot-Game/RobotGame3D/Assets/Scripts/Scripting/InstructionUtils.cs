using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {
	public static class InstructionUtils {

		/// <summary>
		/// Executes the provided instruction as part of a coroutine.
		/// </summary>
		/// <param name="instruction">The instruction to execute.</param>
		/// <returns>Returns true when the execution is finished, and false otherwise.</returns>
		public static IEnumerator ExecuteAsCoroutine(this IInstruction instruction) {
			foreach (var result in instruction.Execute()) {
				yield return result;
			}
		}

		/// <summary>
		/// Executes the provided <c>IArgInstruction</c> as part of a coroutine.
		/// The last value in the IEnumerable will be the return value of the execution.
		/// </summary>
		/// <param name="arg">The provided argument.</param>
		/// <returns></returns>
		public static IEnumerable Execute(this IArgInstruction arg) {
			arg.Begin();

			while (!arg.Update()) {
				yield return null;
			}

			yield return arg.End();
		}

		/// <summary>
		/// Executes the provided <c>IArgInstruction</c> as part of a coroutine.
		/// Takes a callback to pass the result to.
		/// </summary>
		/// <param name="arg">The provided argument.</param>
		/// <param name="result">A callback to pass the returned result to.</param>
		/// <returns></returns>
		public static IEnumerable Execute<T>(this IArgInstruction arg, Action<T> result) {
			arg.Begin();

			while (!arg.Update()) {
				yield return null;
			}

			result((T)arg.End());
		}

	}
}
