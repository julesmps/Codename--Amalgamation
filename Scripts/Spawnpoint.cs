using UnityEngine;
using System.Collections;

public class Spawnpoint : MonoBehaviour {

	public GameObject Player;

	//use this at start
	void Awake(){
		Player = GameObject.FindGameObjectWithTag ("Player"); // Make this find the player
		SpawnPlayer();
	}
	
	void SpawnPlayer(){
		Player.transform.position = transform.position; // this calls the player to the spawnpoint
		this.enabled = false; // this ends the function after player has spawned
	}
}
