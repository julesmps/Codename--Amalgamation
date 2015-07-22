using UnityEngine;
using System.Collections;

public class PatrolEnemy : MonoBehaviour {
	
/*
to set this up, attach the script to the enemy.
create two empty game objects and name them waypoint 1 and 2 (you should be able to 
add more that two waypoitns). set the first waypoint exactly where the enemy is
and move the second waypoint in the x,y,or z axis until you reach the desired 
range of the enemy. the enemy should have rigidbody with is kinematic on and gravity off.
*/

	public GameObject Player;
	public GameObject Spawn;
	public int Marker = 0;
	public Transform[] Waypoint;

	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Spawn = GameObject.FindGameObjectWithTag ("Spawn");
	}
	

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, Waypoint[Marker].transform.position, 2 * Time.deltaTime);

		if (transform.position == Waypoint [Marker].transform.position) {
			Marker ++;
		}

		if (Marker == Waypoint.Length) {
			Marker = 0;
		}
	}

	void OnCollisionEnter (Collision c){
		if (c.gameObject.tag == "Player") {
			Player.transform.position = Spawn.transform.position;
		}
	}
}
