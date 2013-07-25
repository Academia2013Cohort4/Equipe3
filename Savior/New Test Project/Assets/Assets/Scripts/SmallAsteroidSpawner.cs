using UnityEngine;
using System.Collections;

public class SmallAsteroidSpawner : MonoBehaviour {
	
	public GameObject asteroidToSpawn;
	float asteroidSpawnRadius = 1.0f;
	float asteroidSpawnSpeed = 8.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter (Collision other) {
	
		if (other.gameObject.name == "Spaceship" || other.gameObject.name == "PrefabBullet(Clone)")
		{
			int numberOfAsteroids = Random.Range(2, 5);
			for(int i = 0; i < numberOfAsteroids; i++)
			{
				SpawnSmallAsteroid();
			}
		}
	}

	
	void SpawnSmallAsteroid() {
	
		GameObject smallAsteroid = Instantiate(asteroidToSpawn) as GameObject; 
			
		float xSpawnPos = (Random.value - 0.5f) * 2;
		float ySpawnPos = (Random.value - 0.5f) * 2;	
		
		Vector3 spawnOffset = new Vector3(xSpawnPos, ySpawnPos, 0);
		spawnOffset.Normalize();
		spawnOffset *= asteroidSpawnRadius;
		smallAsteroid.transform.position = gameObject.rigidbody.transform.position + spawnOffset;
		
		float xSpawnSpeed = (Random.value - 0.5f) * 2;
		float ySpawnspeed = (Random.value - 0.5f) * 2;	
		
		Vector3 spawnDirection = new Vector3(xSpawnSpeed, ySpawnspeed, 0);
		smallAsteroid.rigidbody.velocity = gameObject.rigidbody.velocity;
		smallAsteroid.rigidbody.AddForce((spawnDirection * asteroidSpawnSpeed));
			
		
	}
}
