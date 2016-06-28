using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class PuzzleVolume : MonoBehaviour {

    // List of puzzle elements inside this puzzle volume
    protected List<PuzzleElement> puzzleElements = new List<PuzzleElement>();
    // List of doors in the puzzle
    protected List<DoorComponent> doors = new List<DoorComponent>();
    // Whether all puzzle elements have been complete
    protected bool isComplete = false;
    private bool lastIsComplete = false;


    void Update() {
        // Puzzle has to have at least one element to consider being complete
        isComplete = puzzleElements.Count > 0;
        for (int i = 0; i < puzzleElements.Count; i++ ) {
            if (!puzzleElements[i].isComplete) {
                isComplete = false;
                break;
            }
        }
   
        // If the puzzle has just been completed, trigger callback
        if (isComplete && !lastIsComplete) {
            OnPuzzleComplete();
        } else if (lastIsComplete && !isComplete) {
            OnPuzzleNotComplete();
        }
        lastIsComplete = isComplete;
    }

    void OnTriggerEnter(Collider other) {
        AddRemovePuzzleElement(other.gameObject);
        AddRemoveDoor(other.gameObject);
    }

    void OnTriggerExit(Collider other) {
        AddRemovePuzzleElement(other.gameObject);
        AddRemoveDoor(other.gameObject);
    }

    /// <summary>
    /// Sets active state on all doors in the puzzle
    /// </summary>
    /// <param name="active">Whether the door should be activated</param>
    public void SetDoorsActive(bool active) {
        foreach (DoorComponent door in doors) {
            if (active) door.OnActivate();
            else door.OnDeactivate();
        }
    }

    /// <summary>
    /// Called as soon as all puzzle elements become complete
    /// </summary>
    protected abstract void OnPuzzleComplete();
    /// <summary>
    /// Called as soon as one puzzle element becomes not complete 
    /// after the puzzle has already been completed
    /// </summary>
    protected abstract void OnPuzzleNotComplete();

    /// <summary>
    /// Checks if the provided game object has a PuzzleElement component, 
    /// and if it does, adds it if it's not tracked, or removes it if it is
    /// </summary>
    /// <param name="other">GameObject to check PuzzleElement for</param>
    private void AddRemovePuzzleElement(GameObject other) {
        PuzzleElement puzzleElement = other.GetComponent<PuzzleElement>();
        if (!puzzleElement) return;
        if (puzzleElements.Contains(puzzleElement)) {
            puzzleElements.Remove(puzzleElement);
        } else {
            puzzleElements.Add(puzzleElement);
        }
    }

    /// <summary>
    /// Checks if the provided game object has a DoorComponent, 
    /// and if it does, adds it if it's not tracked, or removes it if it is
    /// </summary>
    /// <param name="other">GameObject to check DoorComponent for</param>
    private void AddRemoveDoor(GameObject other) {
        DoorComponent door = other.GetComponent<DoorComponent>();
        if (!door) return;
        if (doors.Contains(door)) {
            doors.Remove(door);
        } else {
            doors.Add(door);
        }
    }
}
