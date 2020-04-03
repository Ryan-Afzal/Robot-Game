using Assets.Scripts.Scripting.Block;
using Assets.Scripts.Scripting.Block.Instructions;
using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting {
	public class BlockController : MonoBehaviour {

		public InstructionController instructionController;

		private ISet<EventTriggerBlock> eventTriggers;

		public event Action<string> onBlockRegistered, onBlockRemoved;

		public void Awake() {
			this.eventTriggers = new HashSet<EventTriggerBlock>();
		}

		public bool RegisterTriggerBlock(EventTriggerBlock block) {
			if (this.eventTriggers.Add(block)) {
				this.onBlockRegistered.Invoke(block.GetName());

				return true;
			} else {
				return false;
			}
		}

		public bool RemoveTriggerBlock(EventTriggerBlock block) {
			if (this.eventTriggers.Remove(block)) {
				this.onBlockRemoved.Invoke(block.GetName());

				return true;
			} else {
				return false;
			}
		}

		/// <summary>
		/// Turns all instructions into a node graph representation and binds it to event triggers on the <see cref="InstructionController"/>.
		/// </summary>
		public void CompileAllInstructions() {
			this.instructionController.ClearEvents();

			foreach (var block in this.eventTriggers) {
				this.instructionController.RegisterEvent(block.GetName(), block.GetCompiledInstruction());
			}
		}

	}
}
