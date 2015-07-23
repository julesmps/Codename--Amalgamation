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
	


	// Called when script is intiated
	void Start () {
		
		// Get player rigidbody component and prevent rotation
		player = GetComponent<Rigidbody> ();
		player.freezeRotation = true;
	}



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

	// Needed for z translation
	bool isTranslatingZ = false;

	// Coroutine needed to excucute Z movements +
	private IEnumerator zTranslationPositive () {

		// Loop moves players based on speed
		for (float f = 0f; f < 3; f += speed) {
			player.transform.position += new Vector3 (0.0f, 0.0f, speed);
			// Cannot move along Z until done moving
			isTranslatingZ = true;
			yield return null;
		}
		// Once finished movement is allowed
		isTranslatingZ = false;
	}

	// Coroutine needed to excucute Z movements -
	private IEnumerator zTranslationNegative () {

		// Loop moves players based on speed
		for (float f = 3f; f > 0; f -= speed) {
			player.transform.position -= new Vector3 (0.0f, 0.0f, speed);
			// Cannot move along Z until done moving
			isTranslatingZ = true;
			yield return null;
		}
		// Once finished movement is allowed
		isTranslatingZ = false;
	}

	// Called once per frame
	void Update () {

		// If jump key then jump
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (jumps < 2){
				player.velocity = new Vector2(0.0f, Input.GetAxis ("Jump") * jumpPower);
				jumps++;
			}
		}

		// Moves player up on screen
		if (Input.GetKeyDown ("up") && isTranslatingZ == false && player.transform.position.z < 2) {
			StartCoroutine("zTranslationPositive");
		}
		
		// Moves player down on screen
		if (Input.GetKeyDown ("down") && isTranslatingZ == false && player.transform.position.z > -2) {
			StartCoroutine("zTranslationNegative");
		}

		// Handles all lateral movement
		float sprint = Input.GetAxis ("Sprint") * sprintBonus + 1;
		transform.Translate (new Vector3 (Input.GetAxis ("Horizontal") * speed * sprint, 0.0f, 0.0f));
	}
}