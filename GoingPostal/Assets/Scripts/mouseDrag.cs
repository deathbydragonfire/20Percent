using UnityEngine;
using System.Collections;

public class mouseDrag : MonoBehaviour {

	private bool dragging = false;
	private float distance;

	void OnMouseDown()
	{
		print ("DOWN");
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}
	
	void OnMouseUp()
	{
		print ("UP");
		dragging = false;
	}
	
	void Update()
	{
		if (dragging)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}
