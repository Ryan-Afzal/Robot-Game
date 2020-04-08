using Assets.Scripts.Scripting.Compiled;
using Assets.Scripts.Scripting.Compiled.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block.Instructions {
	public class BoolArgument : Argument {

		public InputField inputFieldPrefab;
		
		private InputField inputField;

		protected override string[] Text => null;

		public override void InitializeTextAndArgSockets(string[] text) {
			this.argSockets = new ArgSocket[0];
			var bar = Instantiate(this.horizontalBarPrefab, GetComponent<RectTransform>());
			this.inputField = Instantiate(this.inputFieldPrefab, bar.transform);
		}

		protected override IArgInstruction Compile() {
			return new LiteralArgInstruction(bool.Parse(this.inputField.text.ToLower()));
		}

	}
}
