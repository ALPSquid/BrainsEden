using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Handles mapping between game-friendly actions and Unity InputManager
/// </summary>
public static class InputMappings {

    public enum EAction {
        MOVE_FORWARD, MOVE_RIGHT, JUMP, PUSH, PULL, SWITCH_PHASE, INTERACT, RESTART
    }

    private static Dictionary<EAction, string> inputNames = new Dictionary<EAction,string> {
        {EAction.MOVE_FORWARD, "Move Forward"},
        {EAction.MOVE_RIGHT, "Move Right"},
        {EAction.JUMP, "Jump"},
        {EAction.PUSH, "Push"},
        {EAction.PULL, "Pull"},
        {EAction.SWITCH_PHASE, "Switch Phase"},
        {EAction.INTERACT, "Interact"},
        {EAction.RESTART, "Restart"}
    };

    private static List<EAction> Axes = new List<EAction> {
        EAction.MOVE_FORWARD,
        EAction.MOVE_RIGHT,
    };

    private static Dictionary<EAction, float> axisDeadzones = new Dictionary<EAction, float>() {
        {EAction.MOVE_FORWARD, 0},
        {EAction.MOVE_RIGHT, 0}
    };

    // Whether the button can be held down or must be released between triggers
    private static Dictionary<EAction, bool> canBeHeld = new Dictionary<EAction, bool>() {
        {EAction.JUMP, false},
        {EAction.PUSH, true},
        {EAction.PULL, true},
        {EAction.SWITCH_PHASE, false},
        {EAction.INTERACT, false},
        {EAction.RESTART, false}
    };

    /// <summary>
    /// Returns physical input for a specified action
    /// </summary>
    /// <param name="action">Action to query input for</param>
    /// <returns>Float Axis value, or 0 or 1 for buttons</returns>
    public static float GetInput(EAction action) {
        if (Axes.Contains(action)) {
            float input =  Input.GetAxis(inputNames[action]);
            return (Mathf.Abs(input) > axisDeadzones[action]) ? input : 0;
        }
        if (canBeHeld[action]) {
            return Input.GetButton(inputNames[action]) ? 1 : 0;
        }
        return Input.GetButtonDown(inputNames[action])? 1 : 0;
    }	
}
