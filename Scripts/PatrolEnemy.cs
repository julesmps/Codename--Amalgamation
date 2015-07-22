using UnityEngine;
using System.Collections;

public class PatrolEnemy : MonoBehaviour {

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
