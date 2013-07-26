using UnityEngine;
using System.Collections;

public class DoorSwitch : MonoBehaviour {
	
	public GameObject door;
	public GUIText    helpInfo;
	
	void Start() {
		helpInfo.pixelOffset = new Vector3(-Screen.width / 2, -Screen.height / 2, 0);
	}
	
	void OnTriggerStay (Collider _collider) {
		if (_collider.tag == "Player") {
			helpInfo.text = "Press 'E' to unlock a door";
			
			if(Input.GetKeyDown (KeyCode.E)) {
				door.GetComponent<DoorScript>().isUnlocked = true;
				
				helpInfo.active = false;
			}
		}
	}
	
	void OnTriggerExit() {
		helpInfo.text = "";	
	}
}
