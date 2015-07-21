using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsDatabase : MonoBehaviour {

	void Awake () {

		Item id0 = new Item (){ id = 4, name = "four", description = "four"};
		List<Item> db = new List<Item> {
			new Item(){ id = 
						0, 
						name = 
						"", 
						description = 
						"" 
			},
			new Item(){ id = 
						1, 
						name = 
						"one", 
						description = 
						"the first item" 
			},
			new Item(){ id = 
						2, 
						name = 
						"two", 
						description = 
						"the second item" 
			}
		};
		db.Add (id0);

		foreach (Item i in db)
			Debug.Log (i.name);
	}
}
