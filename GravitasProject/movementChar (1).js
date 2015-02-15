#pragma strict

public var Gravitron : GameObject;
public var Ground : GameObject;

public var accX = 1.5;
public var accY = 1.5;
public var accDir : float; 

var onGround : boolean = true;
var inGravitron : boolean = true;
var accVec : Vector2;

public var accPower : float = 1000;

function Boost (gravAngle) {
	accDir = gravAngle;
}

function Start () {
	accVec = new Vector2(Mathf.Cos(-accDir)*accPower, Mathf.Sin(-accDir)*accPower);
}

function OnTriggerEnter2D(other : Collider2D) {
	
}

function Update () {

	var movX = Input.GetAxis("Horizontal");
	var movY = Input.GetAxis("Vertical");
	
	rigidbody2D.AddForce(new Vector2(movX * accX, movY * accY));
	
	if (Input.GetKeyDown("space")) {
		rigidbody2D.AddForce(accVec);
	}
}

function OnTriggerStay2D(other : Collider2D) {
	
	if (other.gameObject.tag == "Gravitron") {
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			rigidbody2D.AddForce(accVec);
		}
	}
}