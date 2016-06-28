using UnityEngine;
using System.Collections;

public class CollisionPuzzleElement : PuzzleElement {

	private GameObject target;
    public string targetTag;
    public GameObject targetGameObject;

	void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag.Equals(targetTag) || (targetGameObject != null && collision.gameObject == targetGameObject)) {
            target = collision.gameObject;
			isComplete = true;
		}
	}

	void OnTriggerExit(Collider collision) {
        if (collision.gameObject == target) {
			isComplete = false;
            target = null;
		}
	}
}
