using UnityEngine;
using System.Collections;

public class CosSinDemo : MonoBehaviour {


	//Læg dette script på et GameObject for at få det til at bevæge sig rundt om det i en perfekt cirkel.


	public GameObject center;	//GameObjektet som den skal dreje rundt om
	public float distance;	//Ønskede afstand fra center. Sin og Cos retunerer altid en værdi mellem -1 og 1

	float centerX;
	float centerY;
	float centerU = 0;	//Vinklen mellem objektet og dets centeret.

	public float speed = 0.1f;	//Hastigheden hvormed CenterU ændres.

	// Use this for initialization
	void Start () {
		centerX = center.transform.position.x;
		centerY = center.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		centerU += speed;
		transform.position = new Vector3
			(Mathf.Cos (centerU) * distance + centerX, 
			 Mathf.Sin (centerU) * distance + centerY);
	}
}
