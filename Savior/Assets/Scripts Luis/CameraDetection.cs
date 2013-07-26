using UnityEngine;
using System.Collections;

public class CameraDetection : MonoBehaviour {
#region Public Variables
	public Camera     camera;
	public Transform  target;
	public GameObject spotLight;
	
	public float moveSpeed = 100f;
	public float minYRot   = -45f;
	public float maxYRot   =  45f;
	
	public float viewDistance = 100;
	
	public int timer = 5;
#endregion
	
#region Private Variables
	private int posNeg = 1;
	private bool  isOn = true; 
	private bool isPlayerDetected = false;
#endregion	
	
	void FixedUpdate () {
		if(isOn == true) {
			RotateCamera();
			Patrol();
		}
	}
	
	/// <summary>
	/// Rotates the camera.
	/// </summary>
	void RotateCamera() {
		//Minimum y rotation
		if (this.transform.rotation.y <= minYRot / 100) { 
			posNeg = 1;	
		}	
			// Maxmimum y rotation 
		else if (this.transform.rotation.y >= maxYRot / 100) { 
			posNeg = -1;
		}
		transform.Rotate(0, posNeg * moveSpeed * Time.deltaTime, 0);		
	}
	
	/// <summary>
	/// Turns the off camera.
	/// </summary>
	public void TurnOffCamera() {
		isOn             = false; // Turn off camera
		isPlayerDetected = false;
		
			// Deactivate children (Turn off spotlight)
		foreach (Transform child in this.transform){
    		child.active = isOn;
			
		}	
	}	
	
	/// <summary>
	/// Patrols the area
	/// </summary>
	void Patrol() {
			// Get the ray going through the center of the camera
		Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
		RaycastHit hit; // Do a raycast 
		if (Physics.Raycast(ray, out hit, viewDistance)) {
			if(hit.collider.tag == "Player") { 
				isPlayerDetected = true;
				
				this.transform.LookAt(target); // Look at player
				
				SetSpotLight(Color.yellow, 5); // Set spotlight to yellow
				
				StartCoroutine(Detected());
			}
		} else {
			isPlayerDetected = false;
			
			SetSpotLight(Color.white, 1); // Set spotlight to yellow and 5 intensity
			StopCoroutine("Detected");
		}	
	}
	
	/// <summary>
	/// Sets the spot light.
	/// </summary>
	/// <param name='_color'>
	/// _color.
	/// </param>
	/// <param name='_intensity'>
	/// _intensity.
	/// </param>
	void SetSpotLight(Color _color, float _intensity) {
		spotLight.light.color     = _color;
		spotLight.light.intensity = _intensity;
	}
	
	/// <summary>
	/// Detected player.
	/// </summary>
	IEnumerator Detected() {
		yield return new WaitForSeconds(timer / 2);
		SetSpotLight(Color.red, 5);
		
		yield return new WaitForSeconds(timer / 2);
		if(isPlayerDetected && isOn) {
			Application.LoadLevel("Game Over");
		}
	}
}