using UnityEngine;
using System.Collections;

public class BoulderPuzzle : PuzzleVolume {
	
	protected override void OnPuzzleComplete() {
		SetDoorsActive(true);
	}
	
	protected override void OnPuzzleNotComplete() {
		SetDoorsActive(false);
	}
}
