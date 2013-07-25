using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision other) {
	
		if (other.gameObject.name == "Spaceship" || other.gameObject.name == "Asteroid(Clone)" || other.gameObject.name == "SmallAsteroid(Clone)" || other.gameObject.name == "PrefabBullet(Clone)")
		{
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
