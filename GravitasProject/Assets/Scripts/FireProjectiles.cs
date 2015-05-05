using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireProjectiles : MonoBehaviour
{

	[Tooltip ("The prefab to use as projectile")]
	public GameObject
		projectile;
	[Tooltip("In seconds. Leave at 0 to disable")]
	public float
		fireInterval;
	[Tooltip("Initial speed in the direction it is fired. Needs a Rigidbody")]
	public float
		projectileSpeed = 1;
	[Tooltip ("Angles in degrees. Will fire every direction every time.")]
	public float[]
		directionsToFire;
	


	void Start ()
	{
		StartCoroutine ("fireContinually");
	}

	void Update ()
	{
	
	}

	IEnumerator fireContinually ()
	{
		Vector3 currentPosition;

		while (fireInterval > 0) {
			yield return new WaitForSeconds (fireInterval);

			currentPosition = transform.position;

			for (int i = directionsToFire.Length-1; i> -1; i--) {

				GameObject fired = Instantiate (projectile);
				fired.transform.position = currentPosition;
				fired.transform.eulerAngles = new Vector3 (0, 0, directionsToFire [i]);

				if (fired.GetComponent<Rigidbody2D> ()) {
					Vector2 dirVec = new Vector2 
						(Mathf.Cos (Mathf.Deg2Rad * directionsToFire [i]), 
						 Mathf.Sin (Mathf.Deg2Rad * directionsToFire [i]));
					fired.GetComponent<Rigidbody2D> ().velocity = dirVec * projectileSpeed;
				}
			}
		}
	}
}