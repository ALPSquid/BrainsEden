using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {

	public GameManager.EWorldPhase enabledPhase;
    private bool _isEnabled;
    public bool isEnabled {
        get { return _isEnabled; }
    }

    private Rigidbody body;


    void Awake() {
        body = GetComponent<Rigidbody>();
    }

    void Start() {
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
        _isEnabled = eventPhaseSwitched.currentPhase == enabledPhase;
        body.constraints = (_isEnabled)? RigidbodyConstraints.None : RigidbodyConstraints.FreezeAll;
	}
}
