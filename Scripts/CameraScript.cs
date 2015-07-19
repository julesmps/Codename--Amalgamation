using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	const float distance = 10.0f;
	float height = distance * 0.2f;

	public GameObject player;

	// Use this for initialization
	void Start () {
		position(player);
	}
	
	// Update is called once per frame
	void Update () {
		moveCamera ();
	}

	void position (GameObject target){
		transform.position = new Vector3 (0, 0, target.transform.position.z - distance);
		transform.Rotate(new Vector3(5, 0, 0));
	}

	void moveCamera () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + height, transform.position.z);
	}
}
