using UnityEngine;
using System.Collections;

public abstract class WorldSwitchingComponent : MonoBehaviour {

	void OnEnable(){
		Events.onWorldSwitchEvent += WorldSwitch;
	}

	void OnDisable(){
		Events.onWorldSwitchEvent -= WorldSwitch;
	}

	public abstract void WorldSwitch ();
}
