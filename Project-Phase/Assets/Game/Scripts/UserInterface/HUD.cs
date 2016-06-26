using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	private Text txtInfo;
	private Image whiteOverlay;
	bool ending = false;

	void OnEnable() {
		Cursor.visible = false;
		Events.onTabletPickedUpEvent += EndGame;
	}
	
	void OnDisable() {
		Events.onTabletPickedUpEvent -= EndGame;
	}


	void Start(){
		txtInfo = GameObject.FindWithTag(GameManager.Tags.HUD_INFOTEXT).GetComponent<Text>();
	}

	public void displayText(string textValue){
		txtInfo.text = textValue;
	}

	void EndGame(){
		ending = true;
		Events.onCreditsStartedEvent();
	}
}
