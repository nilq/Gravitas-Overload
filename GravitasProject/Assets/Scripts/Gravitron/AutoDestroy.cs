/*
Destroys the GameObject to which it is attatched after the delay has passed.
*/
using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{

	public float delay = 1;

	// Use this for initialization
	void Start ()
	{
		GameObject.Destroy (gameObject, delay);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
