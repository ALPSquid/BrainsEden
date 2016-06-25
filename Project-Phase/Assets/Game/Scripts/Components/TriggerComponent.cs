using UnityEngine;
using System.Collections;

public abstract class TriggerComponent : MonoBehaviour {

	[Tooltip("Object that triggers event")]
	public GameObject triggerObject;
		
	void OnCollisionEnter(Collision collision) {
		TriggerEvent(collision.gameObject);
	}

	public abstract void TriggerEvent(GameObject collision);
}