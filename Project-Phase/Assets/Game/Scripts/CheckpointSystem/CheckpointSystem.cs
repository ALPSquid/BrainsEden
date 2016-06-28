using UnityEngine;
using System.Collections;

public class CheckpointSystem : MonoBehaviour {

	public int currentCheckpoint = 0;
	Vector3 spawnPosition;

	void Start(){
        currentCheckpoint = PlayerPrefs.GetInt("CURRENT_CHECKPOINT");
        CheckpointComponent[] checkpoints = GameObject.FindObjectsOfType<CheckpointComponent>();
        foreach (CheckpointComponent checkpoint in checkpoints) {
			int checkpointID = checkpoint.OrderID;
			if (currentCheckpoint == checkpointID){
				spawnPosition = checkpoint.transform.position;
				break;
			}
		}
        GameObject player = GameObject.FindGameObjectWithTag(GameManager.Tags.PLAYER);
        player.transform.position = spawnPosition;
	}
	
	void OnEnable(){
		Events.onCheckpointActivatedEvent += CheckCheckpoint;
        Events.onPlayerDeathEvent += SaveCheckpoint;
        Events.onLevelReloadedEvent += SaveCheckpoint;
	}
	
	void OnDisable(){
		Events.onCheckpointActivatedEvent -= CheckCheckpoint;
		Events.onPlayerDeathEvent -= SaveCheckpoint;
        Events.onLevelReloadedEvent -= SaveCheckpoint;
	}
	
	void CheckCheckpoint(Events.EventCheckpointActivated eventChecpointActivated){		
		GameObject checkpointObject = eventChecpointActivated.checkpointObject;
		CheckpointComponent checkpointComponent = checkpointObject.GetComponent<CheckpointComponent>();
		
		if (checkpointComponent.OrderID > currentCheckpoint){
			currentCheckpoint = checkpointComponent.OrderID;
			Debug.Log("New Checkpoint Set");
		}
	}

	void SaveCheckpoint(){
		PlayerPrefs.SetInt("CURRENT_CHECKPOINT", currentCheckpoint);
		//Events.onGameEndEvent();
	}
}
