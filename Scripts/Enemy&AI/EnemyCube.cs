using UnityEngine;
using System.Collections;

public class EnemyCube : EnemyAI {

	EnemyCube (): base (2.2f, 10.0f) {

	}

	public EnemyCube enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<EnemyCube> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
