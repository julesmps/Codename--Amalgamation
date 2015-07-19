using UnityEngine;
using System.Collections;

public class EnemyCubeAI : MonoBehaviour {
	// This SHOULD be some sample AI. Maybe. If I got it working ;)

	public GameObject player;
	public float speed = 1.0f;
	public float range = 10.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (inRange ()) {
			rotate ();
			move ();
		}
	}

	void OnCollisionEnter (Collision collision){
		if(collision.gameObject == player){
			Debug.Log("Game Over?");
			Destroy(player);
			Destroy(gameObject);
		}
	}

	bool inRange () {
		if (Vector3.Distance (player.transform.position, transform.position) <= range) {
			return true;
		} else {
			return false;
		}
	}

	void rotate () {
		Vector3 newDirection = Vector3.RotateTowards (transform.forward, new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.z - transform.position.z), speed * Time.deltaTime, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDirection);
	}

	void move () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
}
