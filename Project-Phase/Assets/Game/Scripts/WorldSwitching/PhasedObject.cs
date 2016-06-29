using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class PhasedObject : WorldSwitchingComponent {

	public Material[] colourMaterials;
	public Material[] alphaMaterials;

    public GameManager.EWorldPhase enabledPhase;
    [SyncVar]
    private bool _isEnabled;
    public bool isEnabled {
        get { return _isEnabled; }
    }
    [SyncVar]
    public bool disableCollider = false;
    private Collider collider;

	[HideInInspector][SerializeField] new Renderer renderer;


	public void Awake() {
		renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
	}

    /*void Start() {
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }*/

    public override void OnStartServer() {
        GameManager gameManager = GameObject.FindGameObjectWithTag(GameManager.Tags.GAME_MANAGER).GetComponent<GameManager>();
        if (gameManager == null) return;
        _isEnabled = gameManager.currentPhase == enabledPhase;
    }

	public override void PhaseSwitched(Events.EventPhaseSwitched eventPhaseSwitched) {	
	    _isEnabled = eventPhaseSwitched.currentPhase == enabledPhase;
		switch (eventPhaseSwitched.currentPhase){
			case GameManager.EWorldPhase.COLOUR:
				renderer.materials = colourMaterials;
				break;
			case GameManager.EWorldPhase.ALPHA:
				renderer.materials = alphaMaterials;
				break;
		}
        if (disableCollider && collider != null) {
            collider.enabled = isEnabled;
        }
	}
}
