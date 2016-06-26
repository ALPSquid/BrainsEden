using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class PhasedObject : WorldSwitchingComponent {

	public Material[] colourMaterials;
	public Material[] alphaMaterials;

	[HideInInspector][SerializeField] new Renderer renderer;

	void Awake() {
		renderer = GetComponent<Renderer>();
	}

	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched) {
		
		switch (eventPhaseSwitched.currentPhase){
			case GameManager.EWorldPhase.COLOUR:
				renderer.materials = colourMaterials;
				break;
			case GameManager.EWorldPhase.ALPHA:
				renderer.materials = alphaMaterials;
				break;
		}
	}
}
