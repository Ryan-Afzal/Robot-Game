﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scripting {

	public abstract class ArgInstruction : Instruction {

		public abstract Type GetOutputType();

	}

}
