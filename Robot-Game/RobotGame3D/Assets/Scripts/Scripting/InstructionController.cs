using Assets.Scripts.Robot;
using Assets.Scripts.Scripting.Block;
using Assets.Scripts.Scripting.Compiled;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting {
	
	public class InstructionController : MonoBehaviour {
		
		public RobotBase robot;

		private IDictionary<object, IInstruction> events;

		public IDictionary<string, object> Variables { get; private set; }

		public void Awake() {
			this.events = new Dictionary<object, IInstruction>();
			Variables = new Dictionary<string, object>();
		}

		public void Start() {
			
		}

		public void Update() {

		}

		public void ClearEvents() {
			this.events.Clear();
		}

		public bool ContainsEventTrigger(object key) {
			return this.events.ContainsKey(key);
		}

		public void RegisterEvent(object key, IInstruction instruction) {
			this.events.Add(key, instruction);
		}

		public async Task InvokeEvent(object key) {
			await this.events[key].ExecuteChainAsync(this.GetExecutionArgs());
		}

		private InstructionExecutionArgs GetExecutionArgs() {
			return new InstructionExecutionArgs() {
				Robot = this.robot,
				Controller = this
			};
		}

	}
}
