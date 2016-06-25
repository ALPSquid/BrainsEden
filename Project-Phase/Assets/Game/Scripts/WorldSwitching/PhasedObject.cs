using UnityEngine;
using System.Collections;

public class PhasedObject : WorldSwitchingComponent {

	public Material[] colourMaterials;
	public Material[] alphaMaterials;

	[HideInInspector][SerializeField] new Renderer renderer;

	void Start(){
		renderer = GetComponent<Renderer> ();
	}

	public override void WorldSwitch(){
		renderer.material = (GameManager.world == true) ? colourMaterials : alphaMaterials;
	}
}
