using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public enum EWorldPhase {
		COLOUR,
		ALPHA
	}
	
	public EWorldPhase currentPhase = EWorldPhase.COLOUR;


    public void switchPhase() {
        currentPhase = (currentPhase == EWorldPhase.COLOUR) ? EWorldPhase.ALPHA : EWorldPhase.COLOUR;
        Events.onPhaseSwitchedEvent(new Events.EventPhaseSwitched(currentPhase));
    }
}
