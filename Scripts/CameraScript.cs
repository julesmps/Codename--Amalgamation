using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	const float distance = 10.0f;

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
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, target.transform.position.z - distance);
	}

	void moveCamera () {
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z);
	}
}
