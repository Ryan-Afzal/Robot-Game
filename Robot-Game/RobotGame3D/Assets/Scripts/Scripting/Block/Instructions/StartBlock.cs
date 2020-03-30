using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class StartBlock : Block {

		public override bool Draggable => false;

		public override string[][] Text => new string[][] {
			new string[] { "Start" }
		};

		public override IInstruction Compile() {
			return this.GetNextBlock().Compile();
		}

	}
}
