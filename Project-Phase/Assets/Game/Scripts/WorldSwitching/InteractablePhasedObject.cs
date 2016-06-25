using UnityEngine;
using System.Collections;

public class InteractablePhasedObject : PhasedObject {

	public GameManager.EWorldPhase enabledPhase;
	
	public sealed override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched){
		
	}
}
