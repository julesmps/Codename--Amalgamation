using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
//Basic GUI for player with a hp value and its hp bar to test the contiouos damage script "lava"
//Attach to the player, and give it the tag Player
	public GameObject player;
	public GameObject spawn;

	// hp related variables
	public float MaxHp = 200;
	public float CurHp = 200;
	public int PlayerLives = 5;
	//End

	// GUI variables
	public GUIStyle BlackBar;
	public GUIStyle HpBar;
	public GUIStyle Textfield;
	//End

	void Awake (){
		player = GameObject.FindGameObjectWithTag ("Player");
		spawn = GameObject.FindGameObjectWithTag ("Spawn");
	}

	void Update (){
		if (CurHp <= 0) {
			CurHp = 0;
		}
		if (CurHp >= MaxHp){
			CurHp = MaxHp;
		}
	}

	void OnGUI (){
	  	
		//health bar
		GUI.Box (new Rect (20, 5, 200, 25), "", BlackBar); //black bar behind the hpbar
		GUI.Box (new Rect (20, 5, CurHp, 25), "", HpBar); // hp bar
		GUI.Box (new Rect (25, 10, 200, 25), "HP: " + CurHp + "/" + MaxHp, Textfield);

	}


}
