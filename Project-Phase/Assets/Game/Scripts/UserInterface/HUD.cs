using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	Text txtInfo;

	void Start(){
		txtInfo = GameObject.FindWithTag(GameManager.Tags.HUD_INFOTEXT).GetComponent<Text>();
	}

	public void displayText(string textValue){
		txtInfo.text = textValue;
	}

}
