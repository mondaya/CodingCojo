using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this before your object is started
	void Awake (){
		Debug.Log ("Executing Awake");
	}

	// Use this for initialization
	void Start () {
		
		Debug.Log ("Executing Start");

		int local = 0;

		for (int i = 0; i < 100; i++) {

			// Make local a little bigger
			local++;

			// Calling MyMethod with value of i
			MyMethod (i);
		}// End of loop

		// How big is the local variable in this method?
		Debug.Log("Local in Start = " + local);

	}

	// Update is called once per physics frame
	void FixedUpdate () {
		Debug.Log ("Executing FixedUpdate");
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("Executing Update");

	}

	void MyMethod(int param){

		// This local has scope only in MyMethod
		int local = 0;// This does nothing to local in Start

		// Is param a multiple of 10?
		if(param % 10 == 0){
			Debug.Log (param);
		}

	}

}