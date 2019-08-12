﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public abstract class StandaloneInstruction : Instruction {

		private DroppableArea next;



		protected override void Awake() {
			base.Awake();
		}

		public abstract IEnumerator Execute(InstructionExecutionArgs args);

	}
}
