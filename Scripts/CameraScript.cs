using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Changed to public
	public const float distance = 10.0f;
	GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - distance);
		transform.Rotate(new Vector3(5.0f, 0.0f, 0.0f));
	}

	void Update () {
		float height = player.transform.position.y * 0.2f;
		transform.position = new Vector3 (player.transform.position.x, (player.transform.position.y + (height / 2)), transform.position.z);
	}
}
