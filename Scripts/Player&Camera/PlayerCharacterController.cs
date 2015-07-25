using UnityEngine;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour {
	
	public float speed = 1.0f;						// Variable to control the speed at which the character moves
	public float sprintBonus = 1.5f;				// Additional speed received from 
	public float jumpPower = 5.0f;					// The strength at which the character jumps
	public float zVal = 3.0f;						// Value used to determine the z movement
	public float gravity = 9.81f;					// Gravity which makes the palyer fall
	public int extraJumps = 1;						// Any additional jumps (1 additional jump will give you a double jump)
	private int jumps = 0;							// Keeps track of jumps

	public float ySpeed = 0.0f;
	public float xSpeed = 0.0f;
	public float zSpeed = 0.0f;

	public KeyCode sprintKey = KeyCode.LeftShift;	// Key used for Sprinting
	public KeyCode jumpKey = KeyCode.Space;			// Key used for Jumping
	public CharacterController controller;			// The Player Controller
	private Vector3 direction;
	
	void Start () {
		CharacterController controller = GetComponent<CharacterController> ();
	}

	void Update () {
		/*
		Debug.Log (controller.isGrounded);
		if (controller.isGrounded) {
			ySpeed = 0.0f;
			if (controller.isGrounded && Input.GetKeyDown (jumpKey)) {
				ySpeed = 5.5f;
			}
		} if (!controller.isGrounded) {
			ySpeed -= gravity * Time.deltaTime;
		}

		if (/*controller.isGrounded && Input.GetKey (jumpKey)) {
			controller.Move(Vector3.up);
		}

		Vector3 velocity = new Vector3 (0.0f, ySpeed, 0.0f);
		controller.Move (velocity * Time.deltaTime);
		*/

		CharacterController controller = GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			jumps = 0;
			// Reads the Horizontal Axis (X axis)
			direction = transform.TransformDirection (new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, 0.0f));
			direction *= speed;
			// Allows sprinting
			if (Input.GetKey (sprintKey) && !Input.GetKey (jumpKey)) {
				direction *= sprintBonus;
			}
			// Allows Jumping
			if (Input.GetKeyDown (jumpKey)) {
				direction.y = jumpPower;
			}
		} else {
			// Allows Jumping while midair (double, triple.... jump)
			if (Input.GetKeyDown (jumpKey) && jumps < extraJumps) {
				direction.y = jumpPower;
				jumps++;
			}
		}
		direction.y -= gravity * Time.deltaTime;		// Adds gravity
		controller.Move (direction * Time.deltaTime);	// Applies all movements calculated above
	}
}
