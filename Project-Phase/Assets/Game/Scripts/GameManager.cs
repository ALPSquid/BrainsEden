using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static class Tags {
        public static string GAME_MANAGER = "GameManager";
        public static string PLAYER = "Player";
        public static string PLAYER_ARM = "PlayerArm";
    }

	public enum EWorldPhase {
		COLOUR,
		ALPHA
	}

	public EWorldPhase currentPhase = EWorldPhase.COLOUR;
	public string level;
	bool cursorVisible = false; // Temp bool to switch cursor visibility

    void OnEnable() {
        Cursor.visible = false;
		Events.onGameEndEvent += ReloadLevel;
		Events.onPlayerDeathEvent += PlayerDied;
    }

	void OnDisable() {
		Events.onGameEndEvent -= ReloadLevel;
		Events.onPlayerDeathEvent -= PlayerDied;
    }
	
    void SwitchPhase() {
        currentPhase = (currentPhase == EWorldPhase.COLOUR) ? EWorldPhase.ALPHA : EWorldPhase.COLOUR;
        Events.onPhaseSwitchedEvent(new Events.EventPhaseSwitched(currentPhase));
    }

	void PlayerDied(){
		Events.onGameEndEvent();
	}
	
	void ReloadLevel(){
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
