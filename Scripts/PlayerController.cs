/** This script makes use of an additional Input from the Input Manager (Edit -> Project Settings -> Input)
 *  Name			: Sprint
 *  Positive button	: left shift
 *  Gravity			: 10
 *  Sensitivity		: 50
 */
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Base speed for the player
	public float speed = 0.2f;

	// Percentage increase in speed due to sprint (100% [1.0f] = twice as fast)
	public float sprintBonus = 0.5f;
	
	// Base jump power for the player
	public float jumpPower = 5.0f;

	// Value which determines the amount mvoed left and right
	public float zVal = 3.0f;
	
	// Gets rigidbody to apply forces
	private Rigidbody player;
	
	void Start () {
		
		// Get player rigidbody component and prevent rotation
		player = GetComponent<Rigidbody> ();
		player.freezeRotation = true;
		
		Debug.Log (player.transform.position.x + ", " + player.transform.position.y + ", " + player.transform.position.z);
		
	}
	
	// Tracks player's jumps
	int jumps = 0;
	
	// On collision with a gameObject (the ground) jump is reset
	void OnCollisionEnter (Collision collision){
		if (collision.gameObject) {
			jumps = 0;
		}
	}
	
	// If the player is not touching the ground when they jump they will
	// only be able to single jump
	void OnCollisionExit (Collision collision){
		if (collision.gameObject) {
			jumps = 1;
		}
	}
	
	void Update () {

		// If jump key than jump
		if (Input.GetAxis ("Jump") > 0 && jumps < 2) {
			player.velocity = new Vector2(0.0f, Input.GetAxis ("Jump") * jumpPower);
			jumps++;
		}

		// current pos as a Vector3
		Vector3 current = player.transform.position;
		
		Vector3 zPlus = current + new Vector3 (0.0f, 0.0f, zVal);
		Vector3 zMinus = current - new Vector3 (0.0f, 0.0f, zVal);
				
		// Moves player up on screen
		if (Input.GetKeyDown ("up") && jumps == 0 && current.z < 3) {
			if (!Physics.Linecast (current, zPlus)) {
				player.transform.position = zPlus;
			}
		}
		
		// Moves player down on screen
		if (Input.GetKeyDown ("down") && jumps == 0 && current.z > -3) {
			if (!Physics.Linecast (current, zMinus)) {
				player.transform.position = zMinus;
			}
		}

		// Handles all lateral movement
		float sprint = Input.GetAxis ("Sprint") * sprintBonus + 1;
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * sprint, 0.0f, 0.0f));
	}
}
