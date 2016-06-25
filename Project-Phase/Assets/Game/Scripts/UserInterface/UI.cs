using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI : MonoBehaviour {
	
	public void ChangeScene(string scene){
		SceneManager.LoadScene(scene);
	}
	
	public void ExitGame(){
		Application.Exit();
	}
	
}