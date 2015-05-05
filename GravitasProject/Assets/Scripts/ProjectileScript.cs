/*
 * Place on an object to have it move forwards(local space) unhindered by any gravity and gravitrons.
 * Will optionally self-destruct when hitting colliders.
*/
using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{

	[Tooltip("Time in seconds before the object is destroyed automatically")]
	public float
		lifetime = 100;
	[Tooltip("Wheter the object is destroyed when touching a collider")]
	public bool
		destroyOnCollision = true;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("I hit something!");
		if (destroyOnCollision && other.isTrigger == false) {
			Destroy (gameObject, Time.fixedDeltaTime);
		}
	}
}
