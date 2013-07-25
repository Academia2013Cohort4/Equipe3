using UnityEngine;
using System.Collections;

public class SpaceshipThrustParticles : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Get the ship's particle objects.
		GameObject flameParticleObject_1 = GameObject.Find("InnerCore");
		GameObject flameParticleObject_2 = GameObject.Find("OuterCore");
		
		GameObject flameLightObject_1 = GameObject.Find("Lightsource");
		
		//If the player is pressing "up" to thrust, we activate the ships particles.
		if (Input.GetButton("Up"))
		{
			flameParticleObject_1.particleEmitter.emit = true;
			flameParticleObject_2.particleEmitter.emit = true;
			flameLightObject_1.light.intensity = 20.0f;
		}
		else
		{
			flameParticleObject_1.particleEmitter.emit = false;
			flameParticleObject_2.particleEmitter.emit = false;
			flameLightObject_1.light.intensity = 0.0f;
		}
	}
}
