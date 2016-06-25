using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	bool world;

	void Awake (){
		SwitchWorld();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			SwitchWorld();
		}
	}

	void SwitchWorld(){
		Events.onWorldSwitchEvent();
		world = !world;
		GameManager.world = world;
	}
}
