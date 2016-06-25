using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles mapping between game-friendly actions and Unity InputManager
/// </summary>
public static class InputMappings {

    public enum EAction {
        MOVE_FORWARD, MOVE_RIGHT, JUMP, PUSH, PULL, SWITCH_PHASE, INTERACT
    }

    private static Dictionary<EAction, string> InputNames = new Dictionary<EAction,string> {
        {EAction.MOVE_FORWARD, "Move Forward"},
        {EAction.MOVE_RIGHT, "Move Right"},
        {EAction.JUMP, "Jump"},
        {EAction.PUSH, "Push"},
        {EAction.PULL, "Pull"},
        {EAction.SWITCH_PHASE, "Switch Phase"},
        {EAction.INTERACT, "Interact"}
    };

    private static List<EAction> Axes = new List<EAction> {
        EAction.MOVE_FORWARD,
        EAction.MOVE_RIGHT,
    };

    private static Dictionary<EAction, float> AxisDeadzones = new Dictionary<EAction, float>() {
        {EAction.MOVE_FORWARD, 0},
        {EAction.MOVE_RIGHT, 0}
    };

    /// <summary>
    /// Returns physical input for a specified action
    /// </summary>
    /// <param name="action">Action to query input for</param>
    /// <returns>Float Axis value, or 0 or 1 for buttons</returns>
    public static float GetInput(EAction action) {
        if (Axes.Contains(action)) {
            float input =  Input.GetAxis(InputNames[action]);
            return (Mathf.Abs(input) > AxisDeadzones[action]) ? input : 0;
        }
        return Input.GetButton(InputNames[action])? 1 : 0;
    }	
}
