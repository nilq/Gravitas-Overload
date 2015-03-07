using UnityEngine;
using System.Collections;

public class SplashAnimation : MonoBehaviour {

	public string nextSceneName;

	// Use this for initialization
	void Start () {
/**/	StartCoroutine (Animate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Animate(){
		Color32 colour = transform.GetComponent<SpriteRenderer> ().color;
		for (byte i = 0;  i<(244);   i = (byte)(i + 10)) {
/**/			transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, i);
			yield return new WaitForSeconds(0);
		}
		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 255);
		yield return new WaitForSeconds (1);

		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 0);
		yield return new WaitForSeconds (0.1f);
		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 255);
		yield return new WaitForSeconds (0.4f);

		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 0);
		yield return new WaitForSeconds (0.1f);
		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 255);
		yield return new WaitForSeconds (0.4f);

		transform.GetComponent<SpriteRenderer> ().color = new Color32 (colour.r, colour.b, colour.g, 0);
		
/**/		Application.LoadLevel (nextSceneName);
			yield break;
	}
}
