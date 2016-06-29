using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

/// <summary>
/// Usage: When the puzzle element criteria is complete, 
/// set isComplete on this component to true
/// </summary>
public class PuzzleElement : NetworkBehaviour {

    // Whether the puzzle element has been completed
    [SyncVar]
    public bool isComplete;
}
