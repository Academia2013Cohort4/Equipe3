using UnityEngine;
using System.Collections;

public class ShipCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision other) {

		if (other.gameObject.name == "Asteroid(Clone)" || other.gameObject.name == "SmallAsteroid(Clone)")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
