using UnityEngine;
using System.Collections;

public class PlayerCharacterController : MonoBehaviour {
	
	public float speed = 0.0f;						// Variable to control the speed at which the character moves at
	public float sprintBonus = 1.5f;				// Additional speed received from 
	public float jumpPower = 5.0f;					// The strength at which the character jumps
	public float zVal = 3.0f;						// Value used to determine the z movement
	public float gravity = 9.81f;					// Gravity which makes the palyer fall
	public int extraJumps = 1;						// Any additional jumps (1 additional jump will give you a double jump)
	private int jumps = 0;							// Keeps track of jumps
	public KeyCode sprintKey = KeyCode.LeftShift;	// Key used for Sprinting
	public KeyCode jumpKey = KeyCode.Space;			// Key used for Jumping
	private CharacterController controller;			// The Player Controller
	private Vector3 direction;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
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
