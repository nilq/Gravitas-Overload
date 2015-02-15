/*using UnityEngine;

using System.Collections;



public class BulletScript : MonoBehaviour {
	
	public float spd = 6.5f;	
	
	void Start () {

		transform.rotation = Random.Range (0.0F, 360.0F);
	}	
	
	void Update () {
		
		rigidbody2D.AddForce (Vector2.right * spd * Time.deltaTime);		
	}	
	
	void OnCollisionEnter (Collision other) {		
		
		Destroy (this.gameObject);
		
	}
	
}*/