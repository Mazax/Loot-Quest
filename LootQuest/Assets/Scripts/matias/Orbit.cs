using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {
	public float speed = 1;

	public Vector3 axis = Vector3.up;


	void FixedUpdate()
	{
		gameObject.transform.Rotate(axis, speed, Space.Self);
	}

}
