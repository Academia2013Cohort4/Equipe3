using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour {
	
	public GameObject asteroidToSpawn;
	
	float timer = 0.0f;
	float timeBetweenAsteroidSpawning = 0.0f;
	float minTimeBetweenSpawns = 1.5f;
	float timeFactor = 4.0f;
	
	float spawnDistanceFactor = 7.0f;
	float targetDistanceFactor = 2.2f;
	
	float asteroidSpeed = 10.0f;
	
	// Use this for initialization
	void Start () {
		timeBetweenAsteroidSpawning = getInitialRandomAsteroidSpawningTime();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		// check if it's time to spawn an asteroid!
		if(timer >= timeBetweenAsteroidSpawning)
		{
			GameObject asteroid = Instantiate(asteroidToSpawn) as GameObject; 
			
			float xSpawnPos = (Random.value - 0.5f) * 2;
			float ySpawnPos = (Random.value - 0.5f) * 2;	
			Vector3 spawnPosition = new Vector3(xSpawnPos, ySpawnPos, 0);
			spawnPosition.Normalize();
			spawnPosition *= (spawnDistanceFactor + Random.value + Random.value);
			spawnPosition.z = gameObject.transform.position.z;
			
			float xDir = (Random.value - 0.5f) * 2;
			float yDir = (Random.value - 0.5f) * 2;	
			Vector3 targetPosition = new Vector3(xDir, yDir, 0);
			targetPosition.Normalize();
			targetPosition *= (targetDistanceFactor + Random.value + Random.value);
			targetPosition.z = gameObject.transform.position.z;
			
			asteroid.transform.position = spawnPosition;
			Vector3 directionVector = targetPosition - spawnPosition;
			directionVector.Normalize();
			directionVector *= (asteroidSpeed * Random.value + asteroidSpeed * Random.value);
			asteroid.rigidbody.AddForce(asteroidSpeed * directionVector);
			
			// reset the random time and the timer
			timeBetweenAsteroidSpawning = getRandomAsteroidSpawningTime();
			timer = 0.0f;
		}
	}
	
	float getInitialRandomAsteroidSpawningTime()
	{
		//hardcoded! no variable! Boo Chris boo!
		return Random.value * 3.0f;
	}
	
	float getRandomAsteroidSpawningTime()
	{
		return minTimeBetweenSpawns + Random.value * timeFactor;
	}
}
