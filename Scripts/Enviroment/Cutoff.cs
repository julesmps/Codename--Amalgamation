using UnityEngine;
using System.Collections;

public class Cutoff : MonoBehaviour {
	
/*
to set up the cutoff set the script to an empty game object and set it
at the points where you dont wnat your player to go pass. to set this 
as an altitude cutoff just change the x axis in the if statement for a y.
*/

	public GameObject Player;
		
	// use this to start
	void Awake(){
		Player = GameObject.FindGameObjectWithTag ("Player"); // make this find the Player
	}

	void Update(){ //if the x coordinate of player position is less or equal to the x of this point
		if (Player.transform.position.x <= transform.position.x) {
			Player.transform.position = transform.position; /*then the possition of the player equals the 
			                                                  possition of point*/
		}
	}
}
