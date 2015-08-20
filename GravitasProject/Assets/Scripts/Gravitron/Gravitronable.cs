/*
Contains an array of all gravitron-forces acting upon it.
Applies the force only from the strongest one at any given time.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gravitronable : MonoBehaviour
{

	public List<Vector3> gravities;
	Rigidbody2D rbody;

	// Use this for initialization
	void Start ()
	{
		try {
			rbody = GetComponent<Rigidbody2D> ();
		} catch (KeyNotFoundException ex) {
			Debug.LogError ("A GameObject without a rigidbody attatched cannot be gravitronable!   " + ex);
		}
	}
	
	void FixedUpdate ()
	{
		Vector3 highest = new Vector3 (0, 0, 0);
		foreach (Vector3 graVec in gravities) {
			if (graVec.magnitude > highest.magnitude) {
				highest = graVec;
			}
		}

		rbody.AddForce (new Vector2 (highest.x, highest.y));
	}
}
