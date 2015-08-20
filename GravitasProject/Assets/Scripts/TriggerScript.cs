using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour
{

	public Vector2 returnCoords;
	public GameObject checkpointMarker;

	void Start ()
	{
		returnCoords = new Vector2 (transform.position.x, transform.position.y);
	}


	void OnTriggerEnter2D (Collider2D other)
	{


		if (other.tag == "Checkpoint") {
			//TODO: Play sound effect; pleasant pling
			returnCoords = new Vector2 (other.transform.position.x, other.transform.position.y);
			checkpointMarker.transform.position = returnCoords;
			//transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}


		if (other.tag == "Hurtful") {
			//TODO: Play sound effect; death
			StartCoroutine (DieDramatically ());   //Die dramatically
			transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);  //Set velocity to 0
			transform.GetComponent<Rigidbody2D> ().angularVelocity = 0f;    //Stop spinning
		}


		if (other.tag == "Goal") {
			//TODO: Make some form of confirmation before travelling. Also an animation.
			if (other.GetComponent<GoalScript> ()) {
				Application.LoadLevel (other.GetComponent<GoalScript> ().levelToLoad);  //Go to the specified level
			} else 
				Debug.LogError ("No GoalScript attatched to Goal! Nothing happens!");

		}


		/*if (other.tag == "Divine Bit"){
			//TODO: Play sound effect; pickup
			if(other.GetComponent<DivineBit>()) {

				if (GameObject.Find("_Ark")){

					char bit = other.GetComponent<DivineBit>().divineBitContent;   //Get Bit
					GameObject.Find("_Ark").GetComponent<ArkScript>().AddBit(bit); //Add bit to list of collected bits
				}
			} else {
				Debug.LogError("No DivineBit attatched to this item! Object is destroyed, but nothing else happens!");
			}
			Destroy(other.gameObject);
		}*/

	}

	IEnumerator DieDramatically ()
	{

		if (!transform.GetComponent<SpriteRenderer> ()) {
			Debug.LogWarning ("No sprite-renderer attatched!");
			transform.position = returnCoords;
			yield break;
		}

		Vector2 stayHere = transform.position;


		for (int i = 7; i !=0; i--) {
			transform.GetComponent<SpriteRenderer> ().color = new Color32 (255, 0, 0, 255);
			yield return new WaitForSeconds (0.01f);
			transform.position = stayHere;
			transform.GetComponent<SpriteRenderer> ().color = new Color32 (0, 0, 0, 255);
			yield return new WaitForSeconds (0.01f);
			transform.position = stayHere;
		}

		transform.GetComponent<SpriteRenderer> ().color = new Color32 (255, 255, 255, 255);
		

		transform.position = returnCoords;
	}

	void OnGUI ()
	{

	}
}
