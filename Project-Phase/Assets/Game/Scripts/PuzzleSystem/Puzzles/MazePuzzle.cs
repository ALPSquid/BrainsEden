using UnityEngine;
using System.Collections;

public class MazePuzzle : PuzzleVolume {

    protected override void OnPuzzleComplete() {
        SetDoorsActive(true);
        Debug.Log("Maze Puzzle complete");
    }

    protected override void OnPuzzleNotComplete() {

    }
}
