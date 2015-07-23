/**
 * This script makes use of a non-standard Tag.
 * For this script to work properly, a Tag with the name "Platform" is required
 */
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Base speed for the player
	[Range (0.01f, Mathf.Infinity)]
	public float speed = 0.2f;

	// Percentage increase in speed due to sprint (100% [1.0f] = twice as fast)
	public float sprintBonus = 0.5f;
	
	// Base jump power for the player
	[Range (0.01f, Mathf.Infinity)]
	public float jumpPower = 5.0f;

	// Value which determines the amount mvoed left and right
	public float zVal = 3.0f;

	// Additional Jumps
	[Range (0, Mathf.Infinity)]
	public int extraJumps = 1;

	// Determines whether the player is touching ground
	private bool grounded;

	// Gets rigidbody to apply forces
	private Rigidbody player;

	// Tracks player's jumps
	private int jumps = 0;

	// Sprint Key
	public KeyCode sprintKey = KeyCode.LeftShift;

	// Jump Key
	public KeyCode jumpKey = KeyCode.Space;

	// Called when script is intiated
	void Start () {
		
		// Get player rigidbody component and prevent rotation
		player = GetComponent<Rigidbody> ();
		player.freezeRotation = true;
	}



	// On collision with a gameObject (the ground) jump is reset
	void OnCollisionEnter (Collision collision){
		if (collision.gameObject) {
			grounded = true;
			jumps = 0;
			player.drag = 5;
		}
	}



	// If the player is not touching the ground when they jump they will
	// only be able to single jump
	void OnCollisionExit (Collision collision){
		if (collision.gameObject.tag == "Platform") {
			grounded = false;
			jumps = 1;
			player.drag = 0;
		}
	}


	// Called once per frame
	void Update () {

		// If jump key then jump
		if (Input.GetKeyDown (jumpKey)) {
			if (jumps < 2){
				//player.velocity = new Vector2(0.0f, Input.GetAxis ("Jump") * jumpPower);
				player.AddForce (new Vector3 (0.0f, Input.GetAxis ("Jump") * jumpPower, 0.0f), ForceMode.Impulse);
				jumps++;
			}
		}

		// current pos as a Vector3
		Vector3 current = player.transform.position;
		
		Vector3 zPlus = current + new Vector3 (0.0f, 0.0f, zVal);
		Vector3 zMinus = current - new Vector3 (0.0f, 0.0f, zVal);
				
		// Moves player up on screen
		if (Input.GetKeyDown ("up") && jumps == 0 && current.z < zVal) {
			if (!Physics.Linecast (current, zPlus)) {
				player.transform.position = zPlus;
			}
		}
		
		// Moves player down on screen
		if (Input.GetKeyDown ("down") && jumps == 0 && current.z > -zVal) {
			if (!Physics.Linecast (current, zMinus)) {
				player.transform.position = zMinus;
			}
		}

		// Handles all lateral movement
		float sprint;
		if (Input.GetKey (sprintKey)) {
			if (grounded) {
				sprint = sprintBonus + 1;
			} else {
				sprint = 1;
			}
		} else {
			sprint = 1;
		}
		//transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * sprint, 0.0f, 0.0f));
		if (grounded) {
			player.AddForce (new Vector3 (Input.GetAxis ("Horizontal") * speed * sprint, 0.0f, 0.0f), ForceMode.VelocityChange);
		}
	}
}