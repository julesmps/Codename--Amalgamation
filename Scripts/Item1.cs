using UnityEngine;
using System.Collections;

public class Item1 : Item {
	
	void Start () {
		itemName = "sphere";
		itemDescription = "this object is a sphere";
		itemID = 1;

		itemRigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter() {
		itemRigidbody.velocity = new Vector2 (0.0f, 2.0f);
	}
}
