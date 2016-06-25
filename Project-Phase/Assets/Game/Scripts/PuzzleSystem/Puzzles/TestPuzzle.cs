using UnityEngine;
using System.Collections;

public class TestPuzzle : PuzzleVolume {

    protected override void OnPuzzleComplete() {
        Debug.Log("Puzzle compelete!");
    }

    protected override void OnPuzzleNotComplete() {
        Debug.Log("Puzzle no longer compelete!");
    }
}
