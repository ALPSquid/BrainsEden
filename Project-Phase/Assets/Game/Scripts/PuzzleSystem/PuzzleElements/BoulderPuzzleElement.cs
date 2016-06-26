using UnityEngine;
using System.Collections;

public class BoulderPuzzleElement : PuzzleElement {

	GameObject boulder;

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.tag.Equals(GameManager.Tags.BOULDER)) {
			boulder = collision.gameObject;
			isComplete = true;
			Debug.Log("Puzzle Event Completed!");
		}
	}

	void OnTriggerExit(Collider collision) {
		if (collision.gameObject == boulder){
			isComplete = false;
			boulder = null;
		}
	}
}
