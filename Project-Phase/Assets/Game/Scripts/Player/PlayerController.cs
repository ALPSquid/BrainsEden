using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour {

    public MouseLook mouseLook = new MouseLook();
    private GameManager gameManager;


    void Start() {
        mouseLook.Init(transform, Camera.main.transform);
    }

    void OnEnable() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null) {
            throw new UnityException("Scene needs a GameManager instance with tag 'GameManager'");
        }
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			
		}
        mouseLook.LookRotation(transform, Camera.main.transform);

	}
}
