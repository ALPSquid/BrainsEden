using UnityEngine;
using System.Collections;

public class CheckpointComponent : MonoBehaviour {

	public int OrderID;
	
	
	//When checkpoint activated call the event
	void Activated(){
		Events.EventChecpointActivated eventCheckpointActivated = new Events.EventChecpointActivated();
		eventCheckpointActivated.checkpointObject = this.gameobject;
		
		Events.OnCheckpointActivatedEvent(eventCheckpointActivated);
	}
	
	void OnCollisionEnter(Collision collision) {
        if (collision.gameobject.tag == "Player"){
			Activated();
		}
    }
}
