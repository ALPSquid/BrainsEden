using UnityEngine;
using System.Collections;

public class PhysicsTriggerComponent : TriggerComponent {

	public bool enablePhysics = true;

	public override void TriggerEvent(GameObject collisionObj){

		Rigidbody[] childrenRigidbodies = GetComponentsInChildren<Rigidbody>();

		foreach (Rigidbody rigidbody in childrenRigidbodies){
			rigidbody.isKinematic = enablePhysics;
		} 
	}

}
