using UnityEngine;
using System.Collections;

public class CheckpointSystem : MonoBehaviour {

	void OnEnable(){
		Events.OnCheckpointActivatedEvent += CheckCheckpoint;
	}
	
	void OnDisable(){
		Events.OnCheckpointActivatedEvent -= CheckCheckpoint;
	}
	
	void CheckCheckpoint(Events.EventChecpointActivated eventChecpointActivated){
		
	}
}
