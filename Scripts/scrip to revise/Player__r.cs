/*
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float MaxHealth = 200;
	public float CurHealth = 200; // Curhealth = current health
	public int PlayerLives = 5;
	public float PlayerDef = 1; // PlayerDef = player defence

	// Defence modifications/powerups
	public float DefModTalent = 1;
	public float DefModModifier = 1;
	// End

	// Health modifications/powerups
	public float HealthModTalent = 1;	// if player has a talent which increasses 
	                                    // the health it will be assigned to this number
	public float HealthModModifier = 1; // if player gets a power up which increasses 
	                                    // the health it will be assigned to this number
	// End
	
	// Shield related powerups
	public float DamageResistance; // if we get a puwerup damage will be reduced from here
	public float SetDamageResistanceMaxValue;// this goes with the above
	// End

	// EXP related variables
	public int PlayerLevel = 1; // set level cap
	public float MaxExp = 200;
	public float CurExp = 0; // current exp
	public float NextLevelExpIncrease = 1.375f; // changes the value of the Exp increace each lvlup
	public float NextLevelHealthIncrease = 1.1575f; // changes the value of the Health increace each lvlup
	public float NextLevelDefIncrease = 1.375f; // changes the value of the Defense increase each lvlup
	public float ExperienceMod = 1; // if player gets a powerup that affects Exp gain it goes here
	public float ExperienceModTalent = 1; // if a player has a talent that affects the Exp gain Eg(Exp+5 forever)
	//End

	// GUI
	public GUIStyle Blackbar;
	public GUIStyle Healthbar;
	public GUIStyle TextField;
	public GUIStyle CharName;
	public GUIStyle Expbar;
	// End

	// Text fields
	public string PlayerName = "";
	public string CheatField = "";
	// End

	// Currency & Loot
	public int Coins;
		//loot
	public GameObject CoinItem;
	public GameObject GemItem; // posible brakedown in different gems
			//make sure to add powerups as rare loot
	public GameObject AdditionalLife; // make sure additional life is added
		//Sub End
	// End

	// Bools and tools
	public bool Death = false;
	public bool CheatWindow = false;
	public bool StatWindow = false;
	// End

	// Timers
	public float DespawnCountdown = 1;
	public int Despawn = 5;
		//powerups
	public float WepCooldown = 1;
		//Sub End
	// End

	// Powerups
	public GameObject Fireball;
	public GameObject Iceball;
	public ParticleEmitter InvincibleCloak;
	// End

	//Spawns
	public GameObject Spawn;
	//End

	void Awake () {
		Spawn = GameObject.FindGameObjectWithTag ("Spawn");
		Load ();
	}

	void OnGUI(){

		if (!Death){
		//character stats
		GUI.Box (new Rect (20, 5, 200, 25), "", Blackbar); // Blackbar behind the text
		GUI.Box (new Rect (25, 5, 100, 25), PlayerName, CharName);
		GUI.Box (new Rect (120, 5, 80, 25), "Player level: " + PlayerLevel, CharName);

		//health bar
		GUI.Box (new Rect (20, 35, 200, 25), "", Blackbar);
		GUI.Box (new Rect (20, 35, CurHealth / (PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease), 25), "", Healthbar);
		GUI.Box (new Rect (20, 35, 200, 25), "Health: " + CurHealth + "/" + MaxHealth, TextField);

		//Exp bar
		GUI.Box (new Rect (20, 65, 200, 25), "", Blackbar);
		GUI.Box (new Rect (20, 65, CurExp / (PlayerLevel * ExperienceMod * ExperienceModTalent * NextLevelExpIncrease), 25), "", Expbar);
		GUI.Box (new Rect (20, 65, 200, 25), "Exp: " + CurExp + "/" + MaxExp, TextField);

		//Player currency
		GUI.Box (new Rect (20, 95, 200, 25), "", Blackbar);
		GUI.Box (new Rect (20, 95, 200, 25), "Coins: " + Coins, TextField);

		//lives
		GUI.Box (new Rect (20, 125, 200, 25), "", Blackbar);
		GUI.Box (new Rect (20, 125, 200, 25), "Lives: " + PlayerLives, TextField);
		}

		if (Death) {
			GUI.Box (new Rect (0,0,Screen.width,Screen.height),"\n\n\n\n\n\n\n YOU ARE DEAD \n\n\n you will respawn in " + Despawn + " seconds");
		}
	}

	void Update () {

		MaxHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
		MaxExp = 200 * PlayerLevel * ExperienceMod * ExperienceModTalent * NextLevelExpIncrease;
		PlayerDef = 1 * PlayerLevel * DefModModifier * DefModTalent * NextLevelDefIncrease;

		if (CurHealth >= MaxHealth) {
			CurHealth = MaxHealth;
		}
		if (CurHealth <= 0) {
			CurHealth = 0;
			DeathIdentifier ();
		}
		if (CurExp >= MaxExp) {
			LevelUp();
			CurExp = 0;
		}
		if (CurExp <= 0){
			CurExp = 0;
		}
		if (PlayerLevel >= 100) {
			PlayerLevel = 100;
			CurExp = 0;
		}
		if (PlayerDef <= 0) {
			PlayerDef = 0;
		}
		if (Death) {

			GetComponent<CharacterController>().enabled = false;

			if (DespawnCountdown <= 1) {
				DespawnCountdown -= Time.deltaTime;
			}
			if (DespawnCountdown <= 0) {
				Despawn -= 1;
				DespawnCountdown = 1;
			}
			if (Despawn <= 0) {
				Save ();
				Application.LoadLevel ("level 1");
			}
		}
	}

	void LevelUp(){
		PlayerLevel += 1;
		CurExp = 0;
		CurHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
	}

	void DeathIdentifier(){
		if (PlayerLives >= 0) {
			PlayerLives -=1;
			transform.position = Spawn.transform.position;
			CurHealth = MaxHealth;
		}
		if (PlayerLives < 0) {
			DeathSequence();
		}
	
	}

	void OnTriggerEnter (Collider c){
		if (c.gameObject.name == "Coin") {
			Coins += 1;
		}
	}

	void DeathSequence (){
		Death = true;
		Save ();
	}

	void LootManagement() {

	}

	void Save(){
		PlayerPrefs.SetInt ("PlayerCurrency", Coins);
		PlayerPrefs.SetFloat ("PlayerExp", CurExp);
		PlayerPrefs.SetInt ("PlayerLvl", PlayerLevel);

		Debug.Log ("Saved Coins: " + PlayerPrefs.GetInt("PlayerCurrency") + " Saved Exp: " + PlayerPrefs.GetFloat ("PlayerExp") + " Saved Lvl: " + PlayerPrefs.GetInt ("PlayerLvl"));
	}

	void Load(){

		PlayerName = PlayerPrefs.GetString ("CharName"); // to be set in menu
		Coins = PlayerPrefs.GetInt ("PlayerCurrency");
		PlayerLevel = PlayerPrefs.GetInt ("PlayerLvl");
		CurExp = PlayerPrefs.GetFloat ("PlayerExp");
		// ExperienceMod = PlayerPrefs.GetFloat ("ExperienceMod");
		// ExperienceModTalent = PlayerPrefs.GetFloat ("ExperienceModTalent");
		// HealthModModifier = PlayerPrefs.GetFloat ("HealthModModifier");
		// HealthModTalent = PlayerPrefs.GetFloat ("HealthModTalent");

		// Set stats for basic health
		CurHealth = 200 * PlayerLevel * HealthModModifier * HealthModTalent * NextLevelHealthIncrease;
		// End
	}

	void OnApplicationQuit(){
		Save ();
	}


}
*/