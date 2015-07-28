using UnityEngine;
using System.Collections;

public class Cutoff : MonoBehaviour {
	
/*
to set up the cutoff set the script to an empty game object and set it
at the points where you dont wnat your player to go pass. you have to 
set up one for each of the z planes
*/

	public GameObject Player;
		
	// use this to start
	void Awake(){
		Player = GameObject.FindGameObjectWithTag ("Player"); // make this find the Player
	}

	void Update(){ 
		if (Player.transform.position.z == transform.position.z) { //if the z coordinate of player position is equal to the z of this point
			if (Player.transform.position.x <= transform.position.x) { //if the x coordinate of player position is less or equal to the x of this point
				Player.transform.position = transform.position; /*then the possition of the player equals the 
			                                                  possition of point*/
			}
		}
	}
}
