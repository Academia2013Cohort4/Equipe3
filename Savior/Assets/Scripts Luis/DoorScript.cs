using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	public bool isUnlocked = false;
	public GUIText helpInfo;
	
	public float moveSpeed = 0.2f;
	public float minX = 0;
	public float maxX = 2;
	
	public float minZ = 0;
	public float maxZ = 0;
	
	private bool openDoor = false;
	
	private float originalX;
	private float originalY;
	private float originalZ;
	
	void Start() {
		originalX = this.transform.position.x;
		originalY = this.transform.position.y;
		originalZ = this.transform.position.z;
	}
	
	void OnTriggerEnter (Collider _collider) { Debug.Log("in");
		if (_collider.tag == "Player") {
			helpInfo.text = "";
			
			if(isUnlocked == true) {
				openDoor = true;
			} else {
				helpInfo.text = "The door is locked, find the switch.";	
			}
		}
	}
	
	void OnTriggerExit() {
		openDoor = false;
		helpInfo.text = "";
	}
	
	void Update () {
		if (openDoor == true) {
			OpenDoor();
		} else {
			CloseDoor();	
		}
	}
	
	void OpenDoor() {
		if (this.transform.position.x <= maxX) {
			this.transform.Translate(moveSpeed * Time.deltaTime, 0, 0 );
		}
	}
	
	void CloseDoor() {
		if (this.transform.position.x >= originalX && this.transform.position.x >= minX) {
			this.transform.Translate(-moveSpeed * Time.deltaTime, 0, 0 );
		} else {
			this.transform.position.Set(originalX, originalY, originalZ);
		}
	}
}
