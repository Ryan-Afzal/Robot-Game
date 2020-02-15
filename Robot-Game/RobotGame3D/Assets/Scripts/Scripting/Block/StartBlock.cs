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
	public sealed class StartBlock : BlockInstruction {

        public override void Start() {
            base.Start();
            Locked = true;
        }

        public async void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                await Next
                    .GetCompiledInstruction()
                    .ExecuteChainAsync(new InstructionExecutionArgs() { Robot = null });
            }
        }
        public override IInstruction GetCompiledInstruction() {
            throw new InvalidOperationException();
        }
    }
}
