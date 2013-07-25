using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoundaryForce : MonoBehaviour {
	
	//List of objects we are affecting
	List <Collider> escapingColliders;
	
	//Sets how strong the push force is.
	float pushForceMultiplier = 1000.0f;
	
	float maxReboundSpeed = 5.0f;

	// Use this for initialization
	void Start () {
		escapingColliders = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Push all colliders that are outside the trigger into the center of the sphere.
		foreach (Collider collider in escapingColliders)
		{
			if (collider)
			{
				Vector3 pushForce = gameObject.transform.position - collider.transform.position;
				pushForce.Normalize();
				pushForce.z = 0.0f;
				
				collider.rigidbody.AddForce(pushForce * Time.deltaTime * pushForceMultiplier);
				
				//Cap the rebounding object's max speed
				if (collider.rigidbody.velocity.magnitude > maxReboundSpeed)
				{
					collider.rigidbody.velocity = collider.rigidbody.velocity.normalized * maxReboundSpeed;
				}
			}
		}
		
	}
	
	void OnTriggerEnter(Collider other) {
		//Remove the object from the list of objects to push towards the center

		for(int i = escapingColliders.Count - 1; i >= 0; i--)
		{
			if(escapingColliders[i] == other)
			{
				escapingColliders.RemoveAt(i);
			}
		}
	}
	
	void  OnTriggerExit(Collider other) {
		//Add the object to the list of objects to push towards the center, if it isn't already there.	
		bool foundCollider = false;
		foreach (Collider collider in escapingColliders)
		{
			if(collider == other)
			{
				foundCollider = true;
			}
		}
		
		if (foundCollider == false)
		{
			escapingColliders.Add(other);
		}
	}
}


