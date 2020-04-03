using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public abstract class EventTriggerBlock : Block {

		public override void Start() {
			base.Start();
			var controller = GameObject.FindGameObjectWithTag("BlockAndInstructionController")
				.GetComponent<BlockController>();

			controller.RegisterTriggerBlock(this);
		}

		public override bool Droppable => false;

		public override string[][] Text => new string[][] {
			new string[] { this.GetName() }
		};

		protected override IInstruction Compile() {
			return new EventTriggerStartInstruction();
		}

		public abstract string GetName();

	}
}
