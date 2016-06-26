using UnityEngine;
using System.Collections;

public class MazePuzzle : PuzzleVolume {

    protected override void OnPuzzleComplete() {
        SetDoorsActive(true);
    }

    protected override void OnPuzzleNotComplete() {

    }
}
