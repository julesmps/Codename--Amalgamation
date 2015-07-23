using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemsDatabase : MonoBehaviour {

	/*
	 * 
	 * 
	 * Reference ItemsParent.cs for Default information
	 * 
	 * 
	 * v **These Paramaters are Essential** v

	 *	Item idx = new Item (){ 
			id = x,
			name = "name",
			description = "description",
			maxStack = 1,


	 * v **These are unessential paramaters** v
	 * 	Weapons
			isWeapon = true,
			damage = 0,
			durability = 0,
	 *	Food
			isFood = true,
			nurishment = 0,
			size = 0,
	 *	Quest Items
	 *
	 *	DELETE TRAILING ','
	 *
	 */

	void Awake () {
		/*
		Item id0 = new Item (){ 
			id = 0,
			name = "",
			description = "",
			maxStack = 0,
			isNull = true
		};
		Item id1 = new Item (){ 
			id = 1,
			name = "item",
			description = "",
			maxStack = 1
		};
		Item id2 = new Item (){
			id = 2,
			name = "item",
			description = "",
			maxStack = 1
		};
		Item id3 = new Item (){ 
			id = 3,
			name = "food",
			description = "",
			maxStack = 1,

			isFood = true,
			nurishment = 1,
			size = 10,
		};
		Item id4 = new Item (){
			id = 4,
			name = "weapon",
			description = "",
			maxStack = 1,

			isWeapon = true,
			damage = 1,
			durability = 100
		};
		

		List<Item> db = new List<Item> ();

		db.Add (id0);
		db.Add (id1);
		db.Add (id2);
		db.Add (id3);
		db.Add (id4);

		foreach (Item i in db) {
			Debug.Log (i.name);
		}
	}
	*/
	}
}