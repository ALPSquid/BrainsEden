using UnityEngine;
using System.Collections;

public static class Events {

	public struct EventCheckpointActivated {
		public GameObject checkpointObject;

		public EventCheckpointActivated(GameObject checkpointObject) {
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
	
	public delegate void OnPlayerDeath();
	public static OnPlayerDeath onPlayerDeathEvent;
	
	public delegate void OnGameEnd();
	public static OnGameEnd onGameEndEvent;

	public delegate void OnCheckpointActivated(EventCheckpointActivated eventChecpointActivated);
	public static OnCheckpointActivated onCheckpointActivatedEvent;

	public delegate void OnTabletPickedUp();
	public static OnTabletPickedUp onTabletPickedUpEvent;

	public delegate void OnCreditsStarted();
	public static OnCreditsStarted onCreditsStartedEvent;
}
