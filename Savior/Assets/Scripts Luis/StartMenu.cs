using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	
	void OnGUI (){
		if (GUI.Button (new Rect(Screen.width / 2, Screen.height / 2, 100, 50),"Start Game")){
			Application.LoadLevel("Camera Test");
		}
		if (GUI.Button (new Rect(Screen.width / 2, Screen.height / 2 + 60, 100, 50), "Escape")){
			Application.Quit();
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}