using UnityEngine;
using System.Collections;

public class GameManager{
	
	public enum EWorldPhase {
		COLOUR,
		ALPHA
	}
	
	public EWorldPhase world = EWorldPhase.COLOUR;
}
