using UnityEngine;
using System.Collections;

public class ShipShooting : MonoBehaviour {
	
	public GameObject bulletType;
	
	float bulletSpeed = 400.0f;
	float bulletStartingOffset = 0.8f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Pew Pew!
		if (Input.GetButtonDown("Space"))
		{
			GameObject bullet = Instantiate(bulletType) as GameObject; 
			
			bullet.transform.position = gameObject.transform.position;
			bullet.transform.position += bulletStartingOffset * gameObject.transform.right;
			bullet.rigidbody.AddForce(bulletSpeed * gameObject.transform.right);
		}
		
	}	
}
