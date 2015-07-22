using UnityEngine;
using System.Collections;

public class Myfalloff : MonoBehaviour {

	public GameObject Player;
	public GameObject Spawn;

	// Use this for initialization
	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player"); //find player
		Spawn = GameObject.FindGameObjectWithTag ("Spawn"); //find spawn
	}
	
	// Update is called once per frame
	void Update () { //if player's y position is less or equat to object position 
		if (Player.transform.position.y <= transform.position.y) { 
			Player.transform.position = Spawn.transform.position; // move player to spawn
		}
	}
}
