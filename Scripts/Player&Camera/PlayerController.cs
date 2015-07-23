/**
 * This script makes use of a non-standard Tag.
 * For this script to work properly, a Tag with the name "Platform" is required
 */
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	[Range (0.01f, Mathf.Infinity)]
	public float speed = 1.0f;			// Base speed for the player
	public float sprintBonus = 0.5f;	// Percentage increase in speed due to sprint (100% [1.0f] = twice as fast)
	[Range (0.01f, Mathf.Infinity)]
	public float jumpPower = 10.0f;		// Base jump power for the player
	public float zVal = 3.0f;			// Value which determines the amount mvoed left and right
	[Range (0, Mathf.Infinity)]
	public int extraJumps = 1;			// Additional Jumps
	private Rigidbody player;			// Gets rigidbody to apply forces
	private int jumps = 0;				// Tracks player's jumps
	public KeyCode sprintKey = KeyCode.LeftShift;
	public KeyCode jumpKey = KeyCode.Space;
	
	void Start () {
		
		// Get player rigidbody component and prevent rotation
		player = GetComponent<Rigidbody> ();
		player.freezeRotation = true;
	}

	// On collision with a gameObject (the ground) jump is reset
	void OnCollisionEnter (Collision collision){
		if (collision.gameObject) {
			jumps = 0;
			player.drag = 5;
		}
	}
	
	// If the player is not touching the ground when they jump they will
	// only be able to single jump
	void OnCollisionExit (Collision collision){
		if (collision.gameObject.tag == "Platform") {
			jumps = 1;
			player.drag = 0;
		}
	}

	// Needed for z translation
	bool isTranslatingZ = false;

	// Coroutine needed to excucute Z movements +
	private IEnumerator zTranslationPositive () {

		// Loop moves players based on speed
		for (float f = 0f; f < 3; f += 0.2f) {
			player.transform.position += new Vector3 (0.0f, 0.0f, 0.2f);
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
		for (float f = 3f; f > 0; f -= 0.2f) {
			player.transform.position -= new Vector3 (0.0f, 0.0f, 0.2f);
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
		if (Input.GetKeyDown (jumpKey)) {
			if (jumps < 1 + extraJumps){
				player.AddForce (new Vector3 (0.0f, Input.GetAxis ("Jump") * jumpPower, 0.0f), ForceMode.Impulse);
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
		float sprint;
		if (Input.GetKey (sprintKey)) {
			if (jumps == 0) {
				sprint = sprintBonus + 1;
			} else {
				sprint = 1;
			}
		} else {
			sprint = 1;
		}

		if (jumps == 0) {
			player.AddForce (new Vector3 (Input.GetAxis ("Horizontal") * speed * sprint, 0.0f, 0.0f), ForceMode.VelocityChange);
		} else {
			player.AddForce (new Vector3 (Input.GetAxis ("Horizontal") * (speed / 2), 0.0f, 0.0f), ForceMode.VelocityChange);
		}
	}
}