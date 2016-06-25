using UnityEngine;
using System.Collections;

public class CheckpointComponent : MonoBehaviour {

	public int OrderID;

	void OnEnable(){
		Events.OnCheckpointActivatedEvent += checkPointActivated;
	}

	void OnDisable(){
		Events.OnCheckpointActivatedEvent -= checkPointActivated;
	}
	
	
	//When checkpoint activated call the event
	void checkPointActivated(EventChecpointActivated eventChecpointActivated){
		Events.EventChecpointActivated eventCheckpointActivated = new Events.EventChecpointActivated();
		eventCheckpointActivated.checkpointObject = this.gameobject;
		
		Events.OnCheckpointActivatedEvent(eventCheckpointActivated);
	}
}
