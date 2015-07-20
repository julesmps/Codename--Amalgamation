using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GameObject slots;
	private int x = -62;
	private int y = 80;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 3; i++) {
			for (int k = 0; k < 3; k++) {
				GameObject slot = (GameObject)Instantiate(slots);
				slot.transform.parent = this.gameObject.transform;
				slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
				slot.name = "slot" + i + "." + k;
				if (x == 62){
					x = -62;
					y -= 80;
				} else {
					x += 62;
				}
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
