#pragma strict

function Start () {

}

var heroChar : GameObject;

function Update () {
	transform.position = new Vector3 (heroChar.transform.position.x, heroChar.transform.position.y, transform.position.z);
}