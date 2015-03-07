#pragma strict

function Start () {

}

public var accX = 1.5;
public var accY = 1.5;
public var accDir : Vector2;

function Update () {

	var movX = Input.GetAxis("Horizontal");
	var movY = Input.GetAxis("Vertical");
	
	GetComponent.<Rigidbody2D>().AddForce(new Vector2(movX * accX, movY * accY));
	
	if (Input.GetKeyDown("space")) {
		//rigidbody2D.AddForce(Vector2.MoveTowards());
	}
}