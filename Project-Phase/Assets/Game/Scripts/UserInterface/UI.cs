using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {
	
	public void ChangeScene(string scene){
        Application.LoadLevel(scene);
 
	}
	
	public void ExitGame(){
        Application.Quit();
	}
	
}