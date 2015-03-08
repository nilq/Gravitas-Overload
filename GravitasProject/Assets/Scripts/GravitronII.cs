using UnityEngine;
using System.Collections;

public class GravitronII : MonoBehaviour {

	public float gravAngle;
	public Vector2 forceVector;
	public bool calculateForceVector;
	public bool calculateOnlyOnce;
	public GameObject objectPointingTheRightWay;
	public float gravitationalPower = 1f;
	public float gravPowAnimationmodifier = 0.2f;

	// Update is called once per frame
	void Update () {
		if (calculateForceVector) {
			gravAngle = objectPointingTheRightWay.transform.eulerAngles.z;
			forceVector = new Vector2 
				(Mathf.Cos (Mathf.Deg2Rad * gravAngle + 0) * gravitationalPower, 
				 Mathf.Sin (Mathf.Deg2Rad * gravAngle + 0) * gravitationalPower);

			if(objectPointingTheRightWay.GetComponentInChildren<ParticleSystem>())
				objectPointingTheRightWay.GetComponentInChildren<ParticleSystem>().startSpeed = gravitationalPower * gravPowAnimationmodifier;

			if (calculateOnlyOnce) 
				calculateForceVector = false;
		}
	}

	void OnTriggerStay2D(Collider2D collision){
			if (collision.GetComponent<Rigidbody2D>()) {
			collision.GetComponent<Rigidbody2D>().AddForce(forceVector);
				}
		}
}
