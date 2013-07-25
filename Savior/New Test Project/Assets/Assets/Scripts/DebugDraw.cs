using UnityEngine;
using System.Collections;

public class DebugDraw : MonoBehaviour {
	float sphereRadius = 5.2f;
	float deltaAngle = 0.1f;
	
	
	// Use this for initialization
	void Start () {		
		LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>() as LineRenderer;
		
		int vertexCount = Mathf.RoundToInt(2 * Mathf.PI / deltaAngle) + 1;
		lineRenderer.SetVertexCount(vertexCount);
		lineRenderer.SetWidth(0.4f, 0.4f);
		lineRenderer.SetColors(Color.white, Color.white);
		
	 	Vector3 center = gameObject.transform.position;
		Vector3 initialPoint = new Vector3(center.x + sphereRadius, center.y, center.z);
		//Vector3 prevPoint = initialPoint;
		Vector3 newPoint = new Vector3();
		
		int pointIndex = 0;
		for(float t = 0.0f; t <= 2 * Mathf.PI; t += deltaAngle)
		{
			float newX = center.x + sphereRadius * Mathf.Cos(t);
			float newY = center.y + sphereRadius * Mathf.Sin(t);
			
			newPoint.Set(newX, newY, center.z);
			
			//Debug.DrawLine(prevPoint, newPoint);
			lineRenderer.SetPosition(pointIndex, newPoint);
			
			//prevPoint = newPoint;
			pointIndex++;
		}		
		
		// last line
		lineRenderer.SetPosition(pointIndex, initialPoint);
		//Debug.DrawLine(prevPoint, initialPoint);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
