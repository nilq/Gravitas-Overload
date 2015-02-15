#pragma strict

public var gravAngle : float;
public var gravPower : float;

var uniVec : Vector2;

function Start () {

uniVec = new Vector2(Mathf.Cos(gravAngle)*gravPower, Mathf.Sin(gravAngle)*gravPower);

}


public var changePath : GameObject;

function Update () {}

function OnTriggerStay2D(other : Collider2D) {
	
	if(other.rigidbody2D) {
		
		other.rigidbody2D.AddForce(uniVec);
		other.BroadcastMessage("Boost", gravAngle);
	}
}