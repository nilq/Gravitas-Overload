using UnityEngine;
using System.Collections;

public class BoostScript : MonoBehaviour {

	public float boostRange = 3;
	public float boostPower = 100;
	public Component cameraObject;
	public LayerMask compatibleLayer;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Look what i found! " + rigidbody2D.ToString ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") ) 
		{
			Vector2 position = new Vector2 (transform.position.x, transform.position.y);
			Vector3 mousePosition =  cameraObject.camera.ScreenToWorldPoint(Input.mousePosition);
			Vector2 direction = new Vector2 (mousePosition.x, mousePosition.y) - position;

			RaycastHit2D rayHit = Physics2D.Raycast(position, direction, boostRange, compatibleLayer);

			if (rayHit) {
				rigidbody2D.AddForce(Vector2.ClampMagnitude(direction, 1) * -boostPower);
				//Debug.Log ("Boost recieved of size " + (Vector2.ClampMagnitude(direction, 1) * boostPower).magnitude.ToString() + " and value " + (Vector2.ClampMagnitude(direction, 1) * boostPower).ToString());
			}

			//Debug.Log ("Mouse is at " + mousePosition.ToString() + " and object is at " + position.ToString() + ".");
			//Debug.Log("Resulting direction: " + direction.ToString()+ "  And the ray hit " + rayHit.transform);
		}
	}
}
