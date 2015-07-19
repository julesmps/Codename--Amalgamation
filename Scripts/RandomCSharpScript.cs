using UnityEngine;
using System.Collections;

public class RandomCSharpScript : MonoBehaviour {

	string gameName;

	// Use this for initialization
	void Start () {
		// Some random comment
		welcome (gameName);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void welcome (string name){
		if (name == null) {
			name = "[insert name here]";
		}
		Debug.Log ("Welcome to the development of " + name + ".");
	}
}
