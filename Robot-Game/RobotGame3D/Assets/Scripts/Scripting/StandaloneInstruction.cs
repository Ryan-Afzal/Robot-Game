using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Scripting {

	public abstract class StandaloneInstruction : Instruction<StandaloneInstruction> {

		public StandaloneInstruction Previous { get; private set; }
		public StandaloneInstruction Next { get; private set; }

		public string Name { get; protected set; }
		
		protected override void Awake() {
			base.Awake();
		}

		// For testing right now
		protected virtual void OnGUI() {
			GUI.Box(new Rect(transform.position, new Vector2(100, 50)), Name);
		}

		protected override void OnDrag() {
			Previous.Next = null;
			Previous = null;
		}

		protected override void OnDrop(StandaloneInstruction recipient) {
			recipient.Next = this;
			Previous = recipient;

		}

		public abstract IEnumerator Execute(InstructionExecutionArgs args);
		
	}

}
