using UnityEngine;
using System.Collections;

public class PlayerCubeScript : MonoBehaviour {

	// Base speed for the player
	public float speed = 0.2f;

	// Base Percentage speed for sprint
	public float sprintBonus = 1.5f;

	// Base jump power for the player
	public float jumpPower = 5.0f;

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

		// Finds current posistions
		float currentX = player.transform.position.x;
		float currentY = player.transform.position.y;
		float currentZ = player.transform.position.z;

		// current pos as a Vector3
		Vector3 current = new Vector3 (currentX, currentY, currentZ);


		Vector3 zPlus = new Vector3 (currentX, currentY, currentZ + 3.0f);
		Vector3 zMinus = new Vector3 (currentX, currentY, currentZ - 3.0f);

		// If jump key than jump
		if (Input.GetKeyDown ("space") && jumps < 2) {
			player.velocity = new Vector2(0.0f, jumpPower);
			jumps++;
		}

		// Moves player up on screen
		if (Input.GetKeyDown ("up") && jumps == 0 && player.transform.position.z < 3) {
			if (!Physics.Linecast (current, zPlus)) {
				player.transform.position = new Vector3 (currentX, currentY, currentZ + 3);
			}
		}

		// Moves player down on screen
		if (Input.GetKeyDown ("down") && jumps == 0 && player.transform.position.z > -3) {
			if (!Physics.Linecast (current, zMinus)) {
				player.transform.position = new Vector3 (currentX, currentY, currentZ - 3);
			}
		}

		// Handles all lateral movement
		float xVector = 0.0f;
		if (Input.GetKey ("right")) {
			xVector = speed;
		}
		if (Input.GetKey ("left")) {
			xVector = -speed;
		}
		if (Input.GetKey ("left shift")) {
			xVector *= sprintBonus;
		}
		transform.Translate (new Vector3 (xVector, 0.0f, 0.0f));
	}
}
