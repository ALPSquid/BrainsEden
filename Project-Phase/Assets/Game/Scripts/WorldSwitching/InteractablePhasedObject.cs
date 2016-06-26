using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {

	public GameManager.EWorldPhase enabledPhase;
    private bool _isEnabled;
    public bool isEnabled {
        get { return _isEnabled; }
    }

    private Rigidbody body;
    private Vector3 savedVelocity = Vector3.zero;
    private Vector3 savedAngularVelocity = Vector3.zero;


    void Awake() {
        base.Awake();
        body = GetComponent<Rigidbody>();
    }

    void Start() {
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
        base.PhaseSwitched(eventPhaseSwitched);
        _isEnabled = eventPhaseSwitched.currentPhase == enabledPhase;
        if (_isEnabled) {
            body.constraints = RigidbodyConstraints.None;
            body.velocity = savedVelocity;
            body.angularVelocity = savedAngularVelocity;
        } else {
            savedVelocity = body.velocity;
            savedAngularVelocity = body.angularVelocity;
            body.constraints = RigidbodyConstraints.FreezeAll;
        }	
    }
}
