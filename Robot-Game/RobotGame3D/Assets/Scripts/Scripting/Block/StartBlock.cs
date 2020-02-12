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
	public class StartBlock : BlockInstruction {

        public override void Start() {
            base.Start();
            this.locked = true;
        }

        public async void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                await this.next.GetCompiledInstruction().ExecuteChainAsync(new InstructionExecutionArgs() { Robot = null });
            }
        }

        public override IInstruction GetCompiledInstruction() {
            throw new NotImplementedException();
        }

    }
}
