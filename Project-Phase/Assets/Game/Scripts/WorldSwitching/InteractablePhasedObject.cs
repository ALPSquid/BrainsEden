using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {


    private Rigidbody body;
    private Vector3 savedVelocity = Vector3.zero;
    private Vector3 savedAngularVelocity = Vector3.zero;
    private RigidbodyConstraints savedConstraints;


    void Awake() {
        base.Awake();
        body = GetComponent<Rigidbody>();
        savedConstraints = body.constraints;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
        base.PhaseSwitched(eventPhaseSwitched);
        if (isEnabled) {
            body.constraints = savedConstraints;
            body.velocity = savedVelocity;
            body.angularVelocity = savedAngularVelocity;
        }
        else {
            savedVelocity = body.velocity;
            savedAngularVelocity = body.angularVelocity;
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
