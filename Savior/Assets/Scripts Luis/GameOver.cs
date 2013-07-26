using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 50), "Play Again")) {
			Application.LoadLevel("Camera Test");
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
