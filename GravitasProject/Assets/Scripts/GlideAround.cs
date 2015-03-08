using UnityEngine;
using System.Collections;

public class GlideAround : MonoBehaviour {

	public float glideSpeed;
	public Vector2[] coordinateCycle;

	Vector2 pos;
	int destination = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		pos = transform.position;
		pos = new Vector2 (
			Mathf.MoveTowards (pos.x, coordinateCycle[destination].x,  glideSpeed*Time.deltaTime)
			,
			Mathf.MoveTowards (pos.y, coordinateCycle[destination].y,  glideSpeed*Time.deltaTime)
			);
		transform.position = pos;

		//If transform has reached the destination
		if (Mathf.Approximately(coordinateCycle[destination].x,pos.x) && Mathf.Approximately(coordinateCycle[destination].y, pos.y))
		{
			if (destination < coordinateCycle.Length -1) //Go to the next destination
				destination ++;
			else   //Or start over
				destination = 0;
		}
	}
}
