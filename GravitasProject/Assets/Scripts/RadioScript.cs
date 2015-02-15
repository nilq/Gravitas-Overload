using UnityEngine;
using System.Collections;

public class RadioScript : MonoBehaviour {

	public int stringLength = 50;
	public float typeSpeed = 0.3f;
	public string idleMessage = "(no meaningful information)";
	public string[] message;
	public GUIStyle displayStyle;

	int trCount =0;	//Number of transmissions

	void Start(){
		message = new string[5];	//Array containing the messages of the 5 channels. Please be advised that other parts of the code may rely on this number being 5 exactly.
		}


	bool RecieveTransmission(string content){
		if (trCount < 5) {
						trCount++;
						Debug.Log ("Starting transmission \"" + content + "\" Of length " + content.Length);
						StartCoroutine (PrintOut (content + new string(' ', 50)));
						return true;
				} else
			Debug.LogWarning ("Too many transmissions already. Printing nothing");
			return false;
		}


	void Update(){

		if (Input.GetButtonDown ("Jump")) {
			RecieveTransmission ("Man kan fremadrettet se, at de har været udset til at læse, at der engang skal dannes par af ligheder.");
				}
		}



	void OnGUI(){
		if (message[0]!=null)	//Draw the first channel, but if it's empty...
			GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.3f, Screen.height * 0.1f)
		           , message[0], displayStyle);
		else 	//... draw idleMessage instead.
			GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.3f, Screen.height * 0.1f)
			          , idleMessage, displayStyle);


			for (int i =1; i < message.Length; i++){
				GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.05f + i*displayStyle.fontSize, Screen.width * 0.3f, Screen.height * 0.1f)
				           , message[i], displayStyle);
			}
	}



	 
	IEnumerator PrintOut(string content){
		int cnl=4;	//The channel to print the message to

		for (int i = 4; i>0; i--) {	//Move to the correct channel
			if (cnl - 1 >= 0 && message [cnl - 1] == null) { //Check if there are empty channels below this one
					message [cnl] = null;	//Clear current channel
					cnl--;	//Change channel
			}
		}


		for (int i = 0; i<content.Length - 50; i++) {	//Print out message

			if(cnl-1>=0 && message[cnl-1]==null){ //Keep checking if there are channels below.
				message[cnl] = null;
				cnl--;
			}

			message [cnl] = (content).Substring (i, stringLength);	//Display part of the message; it will appear to be scrolling by.
			yield return new WaitForSeconds (typeSpeed);
		}


		yield return new WaitForSeconds (typeSpeed*2);	//Ending transmission.
		message [cnl] = "(end of transmission)";
		yield return new WaitForSeconds (typeSpeed * 5);
		message [cnl] = null;
		trCount--;
	}

}






