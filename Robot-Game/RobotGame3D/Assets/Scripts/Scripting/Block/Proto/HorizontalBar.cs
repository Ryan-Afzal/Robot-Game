using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Scripting.Block.Proto {

	[RequireComponent(typeof(HorizontalLayoutGroup))]
	public sealed class HorizontalBar : MonoBehaviour {

		private HorizontalLayoutGroup horizontalLayoutGroup;

		public void Awake() {
			this.horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
			this.horizontalLayoutGroup.spacing = 100;
			this.horizontalLayoutGroup.childControlWidth = false;
			this.horizontalLayoutGroup.childControlHeight = false;
			this.horizontalLayoutGroup.childForceExpandWidth = true;
			this.horizontalLayoutGroup.childForceExpandHeight = true;
			this.horizontalLayoutGroup.childScaleWidth = false;
			this.horizontalLayoutGroup.childScaleHeight = false;
		}

		public void Start() {

		}

		public void Update() {

		}

	}

}
