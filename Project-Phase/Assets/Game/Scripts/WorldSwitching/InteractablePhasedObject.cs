using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {


    private Rigidbody body;
    [SyncVar]
    private Vector3 savedVelocity = Vector3.zero;
    [SyncVar]
    private Vector3 savedAngularVelocity = Vector3.zero;
    [SyncVar]
    private RigidbodyConstraints savedConstraints;


    void Awake() {
        base.Awake();
        body = GetComponent<Rigidbody>();
        savedConstraints = body.constraints;
    }
	
	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched) {
        base.PhaseSwitched(eventPhaseSwitched);
        if (!isServer) return;
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

    [ClientRpc]
    private void RpcPhaseSwitched(bool enabled) {
        if (enabled) {
            body.constraints = savedConstraints;
            body.velocity = savedVelocity;
            body.angularVelocity = savedAngularVelocity;
        } else {
            savedVelocity = body.velocity;
            savedAngularVelocity = body.angularVelocity;
            body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
