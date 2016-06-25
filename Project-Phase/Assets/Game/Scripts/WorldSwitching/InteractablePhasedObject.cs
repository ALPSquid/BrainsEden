using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {

	public GameManager.EWorldPhase enabledPhase;
    private bool _isEnabled;
    public bool isEnabled {
        get { return _isEnabled; }
    }

    void OnEnable() {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
        _isEnabled = eventPhaseSwitched.currentPhase == enabledPhase;
	}
}
