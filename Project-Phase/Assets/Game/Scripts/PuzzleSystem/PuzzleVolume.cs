using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleVolume : MonoBehaviour {

    // List of puzzle elements inside this puzzle volume
    protected List<PuzzleElement> puzzleElements = new List<PuzzleElement>();


    void OnTriggerEnter(Collider other) {
        AddRemovePuzzleElement(other.gameObject);
    }

    void OnTriggerExit(Collider other) {
        AddRemovePuzzleElement(other.gameObject);
    }

    /// <summary>
    /// Checks if the provided game object has a PuzzleElement component, 
    /// and if it does, adds it if it's not tracked, or removes it if it is
    /// </summary>
    /// <param name="other">GameObject to check PuzzleElement for</param>
    private void AddRemovePuzzleElement(GameObject other) {
        PuzzleElement puzzleElement = other.GetComponentInParent<PuzzleElement>();
        if (!puzzleElement) return;
        if (puzzleElements.Contains(puzzleElement)) {
            puzzleElements.Remove(puzzleElement);
        } else {
            puzzleElements.Add(puzzleElement);
        }
    }
}
