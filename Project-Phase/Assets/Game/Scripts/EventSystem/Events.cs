using UnityEngine;
using System.Collections;

public static class Events {

	public struct EventChecpointActivated {
		public gameobject checkpointObject;
	}

	public delegate void OnWorldSwitch();
	public static OnWorldSwitch onWorldSwitchEvent;

	public delegate void OnStartPlay();
	public static OnStartPlay onStartPlayEvent;
	
	public delegate void OnPlayerDeath();
	public static OnPlayerDeath onPlayerDeathEvent;

	public delegate void OnCheckpointActivated(EventChecpointActivated eventChecpointActivated);
	public static OnCheckpointActivated OnCheckpointActivatedEvent;
}
