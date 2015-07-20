using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	
	protected string itemName;
	protected string itemDescription;
	protected int itemID; // Item's game id

	protected GameObject itemObj;
	protected Rigidbody itemRigidbody;

	void Start() {
		Debug.Log ("item start");
	}

	/*
	void createItem (string name,
	                 string description,
	                 string id
	                 ) 
	{
		itemName = name;
		itemDescription = description;
		itemID = id;

		itemObj = gameObject;
		itemRigidbody = GetComponent<Rigidbody>;
	}
	*/

}
