using UnityEngine;
using System.Collections;

public class PlayerCubeScript : MonoBehaviour {

	// Gets rigidbody to apply forces
	public Rigidbody player;

	// Base speed for the player
	private float movementSpeed = 100.0F;

	void Start () {

		// Get player rigidbody component
		player = GetComponent<Rigidbody> ();
	
	}

	void FixedUpdate () {

		// Sets translation_h to the axis that the player has specified
		float translation_h = Input.GetAxis ("Horizontal") * movementSpeed;
		translation_h *= Time.deltaTime;

		// Adds translation as a force to the player
		Vector3 movement = new Vector3 (translation_h, translation_h, 0.0F);
		player.AddForce(movement);
	
	}
}
