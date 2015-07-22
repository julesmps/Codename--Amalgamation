using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour {

// For moving
	public int Marker = 0;
	public Transform[] Waypoints;
// End

	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, Waypoints[Marker].transform.position, 2 * Time.deltaTime);
		if (transform.position == Waypoints [Marker].transform.position) {
			Marker ++;
		}
		if (Marker == Waypoints.Length) {
			Marker = 0;
		}
	}
}
