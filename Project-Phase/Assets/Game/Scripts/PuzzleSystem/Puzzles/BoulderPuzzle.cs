using UnityEngine;
using System.Collections;

public class BoulderPuzzle : PuzzleVolume {
	
	protected override void OnPuzzleComplete() {
		Debug.Log("Puzzle Completed!");
		SetDoorsActive(true);
	}
	
	protected override void OnPuzzleNotComplete() {
		SetDoorsActive(false);
	}
}
