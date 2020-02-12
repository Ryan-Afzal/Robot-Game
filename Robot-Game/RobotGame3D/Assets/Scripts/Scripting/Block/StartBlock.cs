using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block {
	public sealed class StartBlock : BlockDraggable {

        public void Start() {
            Locked = true;
        }

        public async void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                await ((BlockInstruction)Next).GetCompiledInstruction().ExecuteChainAsync(new InstructionExecutionArgs() { Robot = null });
            }
        }

        protected override bool CanDrop(OnEndDragArgs args) {
            return true;
        }
    }
}
