using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {

	public GameManager.EWorldPhase enabledPhase;
    private bool _isEnabled;
    public bool isEnabled {
        get { return _isEnabled; }
    }

    void Start() {
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
        _isEnabled = eventPhaseSwitched.currentPhase == enabledPhase;
	}
}
