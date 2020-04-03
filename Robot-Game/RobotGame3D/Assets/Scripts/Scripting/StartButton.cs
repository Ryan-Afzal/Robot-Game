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

	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(Button))]
	[RequireComponent(typeof(RectTransform))]
	public class StartButton : MonoBehaviour {

		public Canvas canvas;

		public GameObject controller;

		private BlockController blockController;
		private InstructionController instructionController;

		private Image image;
		private Button button;
		private RectTransform rectTransform;

		private Color tint = new Color(55, 55, 55);

		public void Awake() {
			this.image = GetComponent<Image>();
			this.button = GetComponent<Button>();
			this.rectTransform = GetComponent<RectTransform>();

			this.blockController = this.controller.GetComponent<BlockController>();
			this.instructionController = this.controller.GetComponent<InstructionController>();

			this.blockController.onBlockRegistered += (key) => {
				if (key is "Start") {
					this.EnablePress();
				}
			};

			this.blockController.onBlockRemoved += (key) => {
				if (key is "Start") {
					this.DisablePress();
				}
			};

			this.DisablePress();
		}

		public void Start() {

		}

		private void EnablePress() {
			this.button.enabled = true;
			this.image.color += this.tint;
		}

		private void DisablePress() {
			this.button.enabled = false;
			this.image.color -= this.tint;
		}

		public async void OnButtonPressed() {
			await this.StartExecution();
		}

		public async Task StartExecution() {
			Debug.Log("###Start###");

			Debug.Log("Compiling...");
			this.blockController.CompileAllInstructions();
			Debug.Log("Done Compiling.");

			Debug.Log("Executing...");
			await this.instructionController.InvokeEvent("Start");
			Debug.Log("Done Executing.");
		}

	}
}
