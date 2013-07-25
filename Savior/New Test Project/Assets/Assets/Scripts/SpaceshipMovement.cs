using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

	//Movement variables
	float turnSpeed = 200.0f;
	float thrustPower = 101100.0f;
	float maxSpeed = 3.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
		//Turn the ship left
		if (Input.GetButton("Left"))
		{
			float shipRotation = Time.deltaTime * -turnSpeed;
			gameObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), shipRotation);
		}
		
		//Turn the ship right
		if (Input.GetButton("Right"))
		{
			float shipRotation = Time.deltaTime * turnSpeed;
			gameObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), shipRotation);		
		}
		
		//Activate the ship's thrust
		if (Input.GetButton("Up"))
		{
			float accelerationForce = Time.deltaTime * thrustPower;
			gameObject.rigidbody.AddForce(accelerationForce * gameObject.transform.right);
		}
		
		
		//Cap the spaceships max speed
		if (gameObject.rigidbody.velocity.magnitude > maxSpeed)
		{
			gameObject.rigidbody.velocity = gameObject.rigidbody.velocity.normalized * maxSpeed;
		}

	}
}
