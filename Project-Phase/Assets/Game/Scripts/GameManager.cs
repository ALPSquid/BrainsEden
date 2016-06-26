using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static class Tags {
        public static string GAME_MANAGER = "GameManager";
        public static string PLAYER = "Player";
        public static string PLAYER_ARM = "PlayerArm";
		public static string CHECKPOINT = "Checkpoint";
        public static string PLAYER_HUD = "PlayerHUD";
        public static string HUD_INFOTEXT = "HUDInfoText";
		public static string HUD_WHITE_OVERLAY = "HUDFadeOver";
        public static string BOULDER = "Boulder";
        public static string MAZE_ORB = "MazeOrb";
    }

	public enum EWorldPhase {
		COLOUR,
		ALPHA
	}

	public EWorldPhase currentPhase = EWorldPhase.COLOUR;
	public string level;
	bool cursorVisible = false; // Temp bool to switch cursor visibility


    void Start() {
        if (Events.onPhaseSwitchedEvent != null) Events.onPhaseSwitchedEvent(new Events.EventPhaseSwitched(currentPhase));
    }

    void OnEnable() {
        Cursor.visible = false;
		Events.onGameEndEvent += ReloadLevel;
		Events.onPlayerDeathEvent += PlayerDied;
		Events.onCreditsStartedEvent += EndLevel;
    }

	void OnDisable() {
		Events.onGameEndEvent -= ReloadLevel;
		Events.onPlayerDeathEvent -= PlayerDied;
		Events.onCreditsStartedEvent -= EndLevel;
    }
	
    public void SwitchPhase() {
        currentPhase = (currentPhase == EWorldPhase.COLOUR) ? EWorldPhase.ALPHA : EWorldPhase.COLOUR;
        if (Events.onPhaseSwitchedEvent != null) Events.onPhaseSwitchedEvent(new Events.EventPhaseSwitched(currentPhase));
    }

    public void ReloadLevel() {
        Application.LoadLevel("Level01");
    }

	private void PlayerDied(){
		Events.onGameEndEvent();
	}

	private void EndLevel(){
		Application.LoadLevel("MainMenu");
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
