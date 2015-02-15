using UnityEngine;

using System.Collections;



public class EnemyScript : MonoBehaviour {
	
	
	
	public GameObject bullet;
	
	public float shootTim = 4.5f;
	
	
	
	float shootStartTim;
	
	
	
	void Start () {
		
		
		
		shootStartTim = shootTim;
		
	}
	
	
	
	void Update () {
		
		
		
		shootTim -= Time.deltaTime;
		
		
		
		if (shootTim < 0) {
			
			
			
			Instantiate (bullet, transform.position, Quaternion.identity);
			
			
			
			shootTim = shootStartTim;
			
		}
		
	}
	
}