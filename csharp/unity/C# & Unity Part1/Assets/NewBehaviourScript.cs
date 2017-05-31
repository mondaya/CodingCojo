using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Output a message about our game
		Debug.Log ("Start method has been called by the engine");

		// A few int variables to play around with
		int playerLives = 3;
		int numberAliens = 10;

		// We can also output the value of variables, like this:
		Debug.Log ("playerLives = " + playerLives);
		Debug.Log ("numberAliens = " + numberAliens);

		// Change the variables a bit
		// Man down! Man down!
		playerLives --;
		// Oh no some more aliens
		numberAliens += 10;

		// Let's do a test
		if (playerLives > 0 && numberAliens > 0) {
			// The test is true so this code will run

			// Output the values again
			Debug.Log ("playerLives = " + playerLives);
			Debug.Log ("numberAliens = " + numberAliens);
		}

		// Fire the nuclear gattling laser
		numberAliens -= 15;

		// Man down! Man down!
		playerLives --;

		// Output the values again
		Debug.Log ("playerLives = " + playerLives);
		Debug.Log ("numberAliens = " + numberAliens);

		// Here is another pointless but demonstrative test
		if (numberAliens > 0) {
			// Game Over Loser!
			Debug.Log ("You Lose!");
		} else {
			// All aliens destroyed
			Debug.Log ("Victory!");

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
