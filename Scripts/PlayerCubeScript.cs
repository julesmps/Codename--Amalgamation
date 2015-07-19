using UnityEngine;
using System.Collections;

public class PlayerCubeScript : MonoBehaviour {

	// Gets rigidbody to apply forces
	public Rigidbody player;

	// Base speed for the player
	public float speed = 100.0f;

	//Base jump power for the player
	public float jumpPower = 5.0f;
	
	void Start () {

		// Get player rigidbody component
		player = GetComponent<Rigidbody> ();
	
	}

	void FixedUpdate () {

		// If jump key than jump
		if (Input.GetKey ("space"))
			player.velocity = new Vector2(0, jumpPower);

		// Sets translations on the ground
		float translation_h = Input.GetAxis ("Horizontal") * speed;
		translation_h *= Time.deltaTime;

		float translation_v = Input.GetAxis ("Vertical") * speed;
		translation_v *= Time.deltaTime;

		// Adds translation as a force to the player
		Vector3 movement = new Vector3 (translation_h, 0.0f, translation_v);
		player.AddForce(movement);
	}
}
