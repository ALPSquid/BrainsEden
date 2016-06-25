using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum EWorldPhase {
		COLOUR,
		ALPHA
	}

	public EWorldPhase currentPhase = EWorldPhase.COLOUR;
	public string level;
	bool cursorVisible = false; // Temp bool to switch cursor visibility

    void OnEnable() {
        Cursor.visible = false;
		Events.OnGameEndEvent += ReloadLevel;
    }

	void OnDisable() {
        Events.OnGameEndEvent -= ReloadLevel;
    }
	
    public void switchPhase() {
        currentPhase = (currentPhase == EWorldPhase.COLOUR) ? EWorldPhase.ALPHA : EWorldPhase.COLOUR;
        Events.onPhaseSwitchedEvent(new Events.EventPhaseSwitched(currentPhase));
    }
	
	public void ReloadLevel(){
		Application.LoadLevel(level);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.LeftControl)) {
			cursorVisible = !cursorVisible;
			if (cursorVisible){
				Cursor.visible = true;
			} else {
				Cursor.visible = false;
			}
		}
	}
}
