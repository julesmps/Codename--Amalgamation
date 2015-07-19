using UnityEngine;
using System.Collections;

public class PlayerCubeScript : MonoBehaviour {

	// Base speed for the player
	public float speed = 100.0f;

	//Base jump power for the player
	public float jumpPower = 5.0f;

	// Gets rigidbody to apply forces
	private Rigidbody player;
	
	void Start () {

		// Get player rigidbody component
		player = GetComponent<Rigidbody> ();
	
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
		if (Input.GetKeyDown ("space") && jumps < 2) {
			player.velocity = new Vector2 (0, jumpPower);
			jumps++;
		}
	}

	void FixedUpdate () {

		// Sets translations on the ground
		float translation_h = Input.GetAxis ("Horizontal") * speed;
		translation_h *= Time.deltaTime;
		float translation_v = Input.GetAxis ("Vertical") * speed;
		translation_v *= Time.deltaTime;

		// Adds translation as a force to the player
		Vector3 translate = new Vector3 (translation_h, 0.0f, translation_v);
		transform.Translate (translate);
	}
}
