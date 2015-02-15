#pragma strict

var GravitronScript;
public var Gravitron : GameObject;
public var Ground : GameObject;

public var accX = 1.5;
public var accY = 1.5;
public var accDir : Vector2; 

var onGround : boolean = true;
var inGravitron : boolean = true;

function Start () {

	GravitronScript = Gravitron.GetComponent("Gravitron.js");

}

function OnTriggerEnter2D(other : Collision) {

		if (other.gameObject == Gravitron) {
			inGravitron = true;
		}
		
		if (other.gameObject == Ground) {
			onGround = true;
		}
}

function Update () {

	var movX = Input.GetAxis("Horizontal");
	var movY = Input.GetAxis("Vertical");
	
	rigidbody2D.AddForce(new Vector2(movX * accX, movY * accY));
	
	if (Input.GetKeyDown("space")) {
		if (onGround && inGravitron) {
			
		}
	}
}