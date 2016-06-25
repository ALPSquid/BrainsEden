using UnityEngine;
using System.Collections;

public class BoulderPuzzleElement : PuzzleElement {

	GameObject boulder;

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag.Equals(GameManager.Tags.BOULDER)) {
			boulder = collision.gameObject;
			isComplete = true;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject == boulder){
			isComplete = false;
			boulder = null;
		}
	}
}
