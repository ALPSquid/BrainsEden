using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles mapping between game-friendly actions and Unity InputManager
/// </summary>
public static class InputMappings {

    public enum EAction {
        MOVE_FORWARD, MOVE_RIGHT, JUMP, PUSH, PULL, SWITCH_PHASE
    }

    private static Dictionary<EAction, string> InputNames = new Dictionary<EAction,string> {
        {EAction.MOVE_FORWARD, "Move Forward"},
        {EAction.MOVE_RIGHT, "Move Right"},
        {EAction.PUSH, "Push"},
        {EAction.PULL, "Pull"},
        {EAction.SWITCH_PHASE, "Switch Phase"}
    };

    /*private static List<EAction> Axes = new List<EAction> {
        EAction.MOVE_FORWARD,
        EAction.MOVE_RIGHT,
    };*/


    /// <summary>
    /// Returns physical input for a specified action
    /// </summary>
    /// <param name="action">Action to query input for</param>
    /// <returns>Float Axis value, or 0 or 1 for buttons</returns>
    public static bool GetInput(EAction action) {
        //if (Axes.Contains(action)) return Input.GetAxis(InputNames[action]);
        //return Input.GetButton(InputNames[action])? 1 : 0;
        return Input.GetButton(InputNames[action]);
    }
	
}
