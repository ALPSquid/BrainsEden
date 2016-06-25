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
	
	void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player"){
			Activated();
		}
    }
}
