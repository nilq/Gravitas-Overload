using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour
{

	//Basic movement
	[Tooltip("The acceleration(per second) along both axes")]
	public float
		acceleration = 1.5f;

	Rigidbody2D rbody;

	//Dashing
	[Tooltip("Minimum time between dashes in seconds")]
	public float
		cooldown = 0.3f;
	float lastDash = 0;
	[Tooltip("The force of the dash")]
	public float
		dashForce = 100;

	//Breaking
	[Tooltip("The amount of angular drag on the rigidbody while breaking.")]
	public float 
		breakingDrag = 5f;
	float defaultDrag;


	// Use this for initialization
	void Start ()
	{
		rbody = GetComponent<Rigidbody2D> ();
		defaultDrag = rbody.drag;
	}

	//Update is called once every frame
	void Update ()
	{
		//Break
		if (Input.GetButtonDown ("Fire3")) {
			defaultDrag = rbody.drag;
			rbody.drag = breakingDrag;
		}
		if (Input.GetButtonUp ("Fire3")) {
			rbody.drag = defaultDrag;
		}
	}

	
	// FixedUpdate is called every physics-update
	void FixedUpdate ()
	{
		//Movement
		Vector2 input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));

		rbody.AddForce (input * acceleration);	//Apply Force


		//Dash
		if (Input.GetButtonDown ("Fire2") && !Input.GetButton ("Fire3")) {
			if (lastDash <= Time.time - cooldown) {	  //If it has been longer than Cooldown since last dash
				rbody.AddForce (input * dashForce);	  //Dash in the direction you were moving
				lastDash = Time.time;   //Reset the counter
				//TODO: add a sound
			}
		}
	}
}
