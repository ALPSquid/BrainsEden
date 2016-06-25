using UnityEngine;
using System.Collections;

public abstract class InteractableLookAtComponent : LookAtComponent {

	[Tooltip("Override infoText")]
	public string action;
	public string name;

	void Start(){
		infoText = action + name;
	}
	
	public abstract void OnInteract();

}
