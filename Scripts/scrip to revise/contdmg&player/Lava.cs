using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

/*
Add this script to a block with a trigger and make sure you put something under it so the player doesnt fall through
you also need to apply the script "Player" to the playable character so it can take life points from it.
	 */

	public GameObject player;
	public GameObject lava;
	public float lavaDmg = 0;
	public float lavaDmgCldwn = 1;
	public int lavaCldwn = 5;
	public bool triggerOn = false;
	public bool whileOnTrigger = false;
	
	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player");
		lava = GameObject.FindGameObjectWithTag ("Lava");
	}

	//recognice that the player is inside the trigger
	void OnTriggerStay (Collider c){
		if (c.gameObject.tag == "Player") {
			whileOnTrigger = true;
		}
	}

	//recognice if the player left the trigger
	void OnTriggerExit (Collider c){
		if (c.gameObject.tag == "Player"){
			whileOnTrigger = false;
			triggerOn = true;
		}
	}

	void Update (){
		//call for variables in the script "Player"
		Player pstats = player.GetComponent<Player>();

		//continous damage while on trigger
		if (whileOnTrigger == true) {
			lavaDmg = 5;

			if (lavaDmgCldwn <= 1){
				lavaDmgCldwn -= Time.deltaTime;
			}
			if (lavaDmgCldwn <= 0){
				pstats.CurHp -= lavaDmg;
				lavaDmgCldwn = 1;
			}
		}

		//count to stop the damage after player leaves trigger
		if (triggerOn == true){
			lavaDmg = 5;
					 
			if (lavaDmgCldwn <= 1){
				lavaDmgCldwn -= Time.deltaTime;
			}
			if (lavaDmgCldwn <= 0){
				pstats.CurHp -= lavaDmg;
				lavaCldwn -= 1;
				lavaDmgCldwn = 1;
			}
			if (lavaCldwn <= 0){
				lavaDmg = 0;
				triggerOn = false;
				lavaCldwn = 5;
			}
		}
	}
}