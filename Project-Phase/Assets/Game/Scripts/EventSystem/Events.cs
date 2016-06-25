using UnityEngine;
using System.Collections;

public static class Events {

	public struct EventChecpointActivated {
		public GameObject checkpointObject;

        public EventChecpointActivated(GameObject checkpointObject) {
            this.checkpointObject = checkpointObject;
        }
	}
	
	public struct EventPhaseSwitched {
		public GameManager.EWorldPhase currentPhase;

        public EventPhaseSwitched(GameManager.EWorldPhase currentPhase) {
            this.currentPhase = currentPhase;
        }
	}

	public delegate void OnPhaseSwitched(EventPhaseSwitched eventPhaseSwitched);
	public static OnPhaseSwitched onPhaseSwitchedEvent;

	public delegate void OnStartPlay();
	public static OnStartPlay onStartPlayEvent;
	
	public delegate void OnPlayerDeath();
	public static OnPlayerDeath onPlayerDeathEvent;
	
	public delegate void OnGameEnd();
	public static OnGameEnd OnGameEndEvent;

	public delegate void OnCheckpointActivated(EventChecpointActivated eventChecpointActivated);
	public static OnCheckpointActivated OnCheckpointActivatedEvent;
}
