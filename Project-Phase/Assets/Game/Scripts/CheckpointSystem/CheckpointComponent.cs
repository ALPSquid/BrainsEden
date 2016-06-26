using UnityEngine;
using System.Collections;

public class CheckpointComponent : MonoBehaviour {

	public int OrderID;

	//When checkpoint activated call the event
	private void Activated(){
		if (Events.onCheckpointActivatedEvent != null){
        	Events.onCheckpointActivatedEvent(new Events.EventCheckpointActivated(this.gameObject));
			Debug.Log("Checkpoint Triggered");
		}
	}
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == GameManager.Tags.PLAYER){
			Activated();
		}
    }
}
