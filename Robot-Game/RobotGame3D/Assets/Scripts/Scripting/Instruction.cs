﻿using Assets.Scripts.Robot;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Scripting {

	public abstract class Instruction : MonoBehaviour {

		public sealed class ArgSocket {

			private ArgInstruction arg;

			public ArgSocket(Type type) {
				InputType = type;
			}

			public Type InputType { get; private set; }

			public bool CanConnect(ArgInstruction arg) {
				if (this.arg) {
					return false;
				} else if (arg.GetOutputType().Equals(InputType)) {
					return true;
				} else {
					return false;
				}
			}

			public bool ConnectArg(ArgInstruction arg) {
				if (this.CanConnect(arg)) {
					this.arg = arg;
					return true;
				} else {
					return false;
				}
			}

			public bool DisconnectArg() {
				if (this.arg) {
					this.arg = null;
					return true;
				} else {
					return false;
				}
			}

		}

		public string textInputString;

		private object[] textWithArgs;

		protected virtual void Awake() {
			int i_ = -1;
			for (int i = 0; i < textInputString.Length; i++) {
				if (textInputString[i] == '$') {
					if (i_ == -1) {
						
					} else {

					}
				}
			}
		}

		protected virtual void Start() {
			
		}

		protected virtual void Update() {

		}

	}

}
