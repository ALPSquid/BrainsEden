using UnityEngine;
using System.Collections;

public class CheckpointComponent : MonoBehaviour {

	//When checkpoint activated call the event
	void Activated(){
		Events.EventChecpointActivated eventCheckpointActivated = new Events.EventChecpointActivated();
		eventCheckpointActivated.checkpointObject = this.gameobject;
		
		Events.OnCheckpointActivatedEvent(eventCheckpointActivated);
	}
}
