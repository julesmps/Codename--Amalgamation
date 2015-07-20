using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Changed to public
	// Sets distance from player
	public const float distance = 10.0f;

	GameObject player;

	void Start () {

		player = GameObject.FindWithTag ("Player");

		// Sets posistion to that of the player with distance and a rotation to look at the player
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - distance);
		transform.Rotate(new Vector3(5.0f, 0.0f, 0.0f));
	}

	void Update () {

		// Sets scaleable height for when the player jumps
		float height = player.transform.position.y * 0.2f;

		// Handles follow cam of player
		transform.position = new Vector3 (player.transform.position.x, (player.transform.position.y + (height / 2)), transform.position.z);
	}
}
