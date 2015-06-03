/*
Checks all objects who enters its trigger for a Gravitronable-Script.
Ads its force to the list of gravities.
Does the same when an object exits as to remove itself again.
*/
using UnityEngine;
using System.Collections;

public class Gravitron : MonoBehaviour
{
	[Tooltip("Force will be applied once per FixedUpdate.")]
	public float
		force = 1;
	[Tooltip("Angle from the local upwards direction in degrees that the gravitron faces.")]
	public float
		directionModifier = 0;
	[Tooltip("Objects with these tags will be checked for a Gravitronable-Script.")]
	public string[]
		tagsToLookFor = {"Player"};

	Vector2 gravityVector;



	void Start ()   //Calculate force-vector
	{
		gravityVector = transform.up * force;
		gravityVector = Quaternion.AngleAxis (-directionModifier, transform.forward) * gravityVector;  //Mathemagical rotation-formula
	}



	void OnTriggerEnter2D (Collider2D collision)
	{
		bool checkThis = false;

		foreach (string tag in tagsToLookFor) {  //Check if the collision has one of the tags we are looking for
			if (collision.CompareTag (tag)) {
				checkThis = true;
				break;
			}
		}

		if (checkThis) {
			Gravitronable gravitronableScript = collision.GetComponent<Gravitronable> ();   //Check if there is a Gravitronable component
			if (gravitronableScript != null) {
				gravitronableScript.gravities.Add (gravityVector);   //Add this gravitrons force to the list.
			}
		}
	}



	void OnTriggerExit2D (Collider2D collision)
	{
		bool checkThis = false;
		
		foreach (string tag in tagsToLookFor) {  //Check if the collision has one of the tags we are looking for
			if (collision.CompareTag (tag)) {
				checkThis = true;
				break;
			}
		}
		
		if (checkThis) {
			Gravitronable gravitronableScript = collision.GetComponent<Gravitronable> ();   //Check if there is a Gravitronable component
			if (gravitronableScript) {
				gravitronableScript.gravities.Remove (gravityVector);   //Remove itself from the list again.
			}
		}
	}
}
