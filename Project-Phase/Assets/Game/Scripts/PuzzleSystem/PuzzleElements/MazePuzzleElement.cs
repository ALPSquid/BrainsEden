using UnityEngine;
using System.Collections;

public class MazePuzzleElement : PuzzleElement {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals(GameManager.Tags.MAZE_ORB)) {
            isComplete = true;
        }
    }
}
