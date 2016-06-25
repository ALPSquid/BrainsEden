using UnityEngine;
using System.Collections;

public class TestPuzzleElement : PuzzleElement {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals(GameManager.Tags.PLAYER)) {
            isComplete = true;
        }
    }
}
