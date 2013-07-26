using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {
	
	public GameObject camera;
	public GUIText    helpInfo;
	
	void Start() {
	}
	
	void OnTriggerStay (Collider _collider) {
		if (_collider.tag == "Player") {
			helpInfo.text = "Press 'E' to turn off a camera";
			
			if(Input.GetKeyDown (KeyCode.E)) {
				camera.GetComponent<CameraDetection>().TurnOffCamera();
				
				helpInfo.active = false;
			}
		}
	}
	
	void OnTriggerExit() {
		helpInfo.text = "";	
	}
}
