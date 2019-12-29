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
		/// Executes the provided instruction and its following instructions as part of a coroutine.
		/// <example>
		/// For example:
		/// <code>
		/// StartCoroutine(ExecuteAsCoroutine(instruction, args));
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="instruction"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IEnumerator ExecuteAsCoroutine(IInstruction instruction, InstructionExecutionArgs args) {
			foreach (var result in ExecuteChain(instruction, args)) {
				yield return result;
			}
		}

		/// <summary>
		/// Executes the provided <c>IInstruction</c> and all of its following instructions sequencially.
		/// </summary>
		/// <param name="instruction"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static IEnumerable ExecuteChain(IInstruction instruction, InstructionExecutionArgs args) {
			var i = instruction;
			while (i is object) {
				foreach (var result in i.Execute(args)) {
					yield return result;
				}

				i = i.Next;
			}
		}

		/// <summary>
		/// Executes the provided <c>IArgInstruction</c> as part of a coroutine.
		/// The last value in the IEnumerable will be the return value of the execution.
		/// </summary>
		/// <param name="arg">The provided argument.</param>
		/// <returns></returns>
		public static IEnumerable Execute(this IArgInstruction arg, InstructionExecutionArgs args) {
			arg.Begin(args);

			while (!arg.Update(args)) {
				yield return null;
			}

			yield return arg.End(args);
		}

		/// <summary>
		/// Executes the provided <c>IArgInstruction</c> as part of a coroutine.
		/// Takes a callback to pass the result to.
		/// </summary>
		/// <param name="arg">The provided argument.</param>
		/// <param name="result">A callback to pass the returned result to.</param>
		/// <returns></returns>
		public static IEnumerable Execute<T>(this IArgInstruction arg, InstructionExecutionArgs args, Action<T> result) {
			arg.Begin(args);

			while (!arg.Update(args)) {
				yield return null;
			}

			result((T)arg.End(args));
		}

	}
}
