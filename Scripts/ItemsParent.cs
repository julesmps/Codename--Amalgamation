using UnityEngine;
using System.Collections;

public class Item {

	/*
	 * int default = 0
	 * string default = 
	 * bool default = false
	 */
	public int id 				{ get; set; }	//default = null DO NOT DEFAULT
	public string name 			{ get; set; }	//default = no name
	public string description 	{ get; set; }	//default = no description

	public int maxStack 		{ get; set; }	//default = null DO NOT DEFAULT, set to a minimum of 1

	public bool isNull 			{ get; set; }	//leave as default DO NOT SET TRUE

	public bool isWeapon 		{ get; set; }	//default = not a weapon
	public int damage 			{ get; set; }	//default = no damage
	public int durability 		{ get; set; }	//default = infinate durability

	public bool isFood 			{ get; set; }	//default = not food
	public int nurishment 		{ get; set; }	//default = no nourishment
	public int size 			{ get; set; }	//default = no size

	public bool isQuest 		{ get; set; }	//default = not a quest item

	void eat() {
		if (isFood) {
			//eat
		}
	}
}
