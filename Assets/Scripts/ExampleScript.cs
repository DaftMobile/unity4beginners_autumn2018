using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	public float rotationY = 5;
	
	private void Update()
	{
		transform.Rotate(new Vector3(0, rotationY * Time.deltaTime, 0));
	}
	
}
