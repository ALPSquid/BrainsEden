using UnityEngine;
using System.Collections;

public class CheckpointSystem : MonoBehaviour {

	public int currentCheckpoint = 0;

	void Start(){
		currentCheckpoint = PlayerPrefs.GetInt("CURRENT_CHECKPOINT");
	}


	void OnEnable(){
		Events.OnCheckpointActivatedEvent += CheckCheckpoint;
		Events.onPlayerDeathEvent += SaveCheckpoint;
	}
	
	void OnDisable(){
		Events.OnCheckpointActivatedEvent -= CheckCheckpoint;
		Events.onPlayerDeathEvent -= SaveCheckpoint;
	}
	
	void CheckCheckpoint(Events.EventChecpointActivated eventChecpointActivated){
		
		GameObject checkpointObject = eventChecpointActivated.checkpointObject;
		CheckpointComponent checkpointComponent = checkpointObject.GetComponent<CheckpointComponent>();
		
		if (checkpointComponent.OrderID > currentCheckpoint){
			currentCheckpoint = checkpointComponent.OrderID;
		}
	}

	void SaveCheckpoint(){
		PlayerPrefs.SetInt("CURRENT_CHECKPOINT", currentCheckpoint);
		Events.OnGameEndEvent();
	}
}
