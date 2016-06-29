using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public abstract class WorldSwitchingComponent : NetworkBehaviour {

	void OnEnable() {
		Events.onPhaseSwitchedEvent += PhaseSwitched;
	}

	void OnDisable() {
		Events.onPhaseSwitchedEvent -= PhaseSwitched;
	}

	public abstract void PhaseSwitched (Events.EventPhaseSwitched eventPhasedSwitched);
}
