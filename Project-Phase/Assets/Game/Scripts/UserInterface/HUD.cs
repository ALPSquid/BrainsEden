using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	private Text txtInfo;

	void Start(){
		txtInfo = GameObject.FindWithTag(GameManager.Tags.HUD_INFOTEXT).GetComponent<Text>();
	}

	public void displayText(string textValue){
		txtInfo.text = textValue;
	}

}
