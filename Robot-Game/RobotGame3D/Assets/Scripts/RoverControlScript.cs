using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverControlScript : MonoBehaviour {

	public HingeJoint[] leftWheels;
	public HingeJoint[] rightWheels;

	public int speed;
	public int maxSpeed;

	private void Start() {
		foreach (var j in leftWheels) {
			j.useMotor = true;
		}
		
		foreach (var j in rightWheels) {
			j.useMotor = true;
		}
	}

	private void Update() {

	}
}
