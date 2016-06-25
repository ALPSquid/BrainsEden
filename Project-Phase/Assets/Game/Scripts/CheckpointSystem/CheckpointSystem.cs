using UnityEngine;
using System.Collections;

public class CheckpointSystem : MonoBehaviour {

	public int currentCheckpoint = 0;

	void OnEnable(){
		Events.OnCheckpointActivatedEvent += CheckCheckpoint;
	}
	
	void OnDisable(){
		Events.OnCheckpointActivatedEvent -= CheckCheckpoint;
	}
	
	void CheckCheckpoint(Events.EventChecpointActivated eventChecpointActivated){
		
		GameObject checkpointObject = eventChecpointActivated.checkpointObject;
		CheckpointComponent checkpointComponent = checkpointObject.GetComponent<CheckpointComponent>();
		
		if (checkpointComponent.OrderID > currentCheckpoint){
			currentCheckpoint = checkpointComponent.OrderID;
		}
	}
}
