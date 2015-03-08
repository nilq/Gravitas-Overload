using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	public Vector2 returnCoords;
	public GameObject checkpointMarker;

	// Use this for initialization
	void Start () {
		returnCoords = new Vector2(transform.position.x,transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter2D(Collider2D other){


		if (other.tag == "Checkpoint"){
			returnCoords = new Vector2 (other.transform.position.x, other.transform.position.y);
			checkpointMarker.transform.position = returnCoords;
			//transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}


		if (other.tag == "Hurtful"){
			StartCoroutine(DieDramatically());
			transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			transform.GetComponent<Rigidbody2D>().angularVelocity = 0f;
		}


		if (other.tag == "Goal"){
			if(other.GetComponent<GoalScript>()) {
				Application.LoadLevel(other.GetComponent<GoalScript>().levelToLoad);
			} else 
				Debug.LogError("No GoalScript attatched to Goal! Nothing happens!");

		}
	}

	IEnumerator DieDramatically(){

		if (!transform.GetComponent<SpriteRenderer>()){
			Debug.LogWarning("No sprite-renderer attatched!");
			transform.position = returnCoords;
			yield break;
		}

		Vector2 stayHere = transform.position;


		for(int i = 7; i !=0; i--){
			transform.GetComponent<SpriteRenderer>().color = new Color32(255,0,0,255);
			yield return new WaitForSeconds(0.01f);
			transform.position = stayHere;
			transform.GetComponent<SpriteRenderer>().color = new Color32(0,0,0,255);
			yield return new WaitForSeconds(0.01f);
			transform.position = stayHere;
		}

		transform.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,255);
		

		transform.position = returnCoords;
	}

	void OnGUI(){

	}
}
