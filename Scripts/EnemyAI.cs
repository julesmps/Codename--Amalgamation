using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	// This SHOULD be some sample AI. Maybe. If I got it working ;)

	GameObject player;
	protected float speed { get; set; }
	public float outerRange = 10.0f;	//AKA Visibility
	public float attackRange = 0.0f;		//How close they need to get to you

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (inRange ()) {
			rotate ();
			move ();
		}
		if (transform.position.y <= -100) {
			Destroy(gameObject);
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
		float distance = Vector3.Distance (player.transform.position, transform.position);
		if (distance <= outerRange && distance >= attackRange) {
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
