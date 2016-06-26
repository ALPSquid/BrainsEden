using UnityEngine;
using System.Collections;

public abstract class WorldSwitchingComponent : MonoBehaviour {

	void OnEnable() {
		Events.onPhaseSwitchedEvent += PhaseSwitched;
	}

	void OnDisable() {
		Events.onPhaseSwitchedEvent -= PhaseSwitched;
	}

	public abstract void PhaseSwitched (Events.EventPhaseSwitched eventPhasedSwitched);
}
