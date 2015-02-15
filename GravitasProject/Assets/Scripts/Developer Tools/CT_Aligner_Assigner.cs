using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	//[ExecuteInEditMode]	//Uncomment to activate script: This is how you fuck up game files. Badly.

public class CT_Aligner_Assigner : MonoBehaviour {


	public bool assignNames = false;	//Check this box to execute the name-assigner script once.
	public bool assignData = false;		//Check this box to execute the data-assigner script once.
	public string nameStart;

	public Dictionary<string, bool> nobrainer;
	public string[] edgedata={"1111", "1110", "1100", "1101", "1010", "1001", "0010", "1000", "0000", "0000", "0000", "0000", "1011", "1010", "1000", "1001", "0110", "0101", "0100", "0001", "0000", "0000", "0000", "0000", "0011", "0010", "0000", "0001", "0010", "1000", "0010", "1000", "0000", "0000", "0000", "0000", "0111", "0110", "0100", "0101", "0100", "0001", "0100", "0001", "0000", "0000", "0000"};
	public string[] nookdata={"0000", "0000", "0000", "0000", "0001", "0010", "0001", "0011", "1011", "1110", "0101", "0011", "0000", "0000", "0000", "0000", "0100", "1000", "1100", "1010", "0111", "1101", "1100", "1010", "0000", "0000", "0000", "0000", "0000", "0001", "0001", "0010", "0001", "0010", "1001", "0110", "0000", "0000", "0000", "0000", "1000", "0010", "0100", "1000", "0100", "1000", "1111"};

	// Use this for initialization
	void Start () {
		nobrainer = new Dictionary<string, bool> ();
		nobrainer.Add ("1", true);
		nobrainer.Add ("0", false);
	}
	
	// Update will be called every time something changes in the editor
	void Update () {
		if (assignNames) {
			Debug.Log("Assigning names to squares currently named " + nameStart +"#");
					NameAssign ();
					assignNames = false;
				}

		if (assignData) {
			Debug.Log (" Assigning data values to squares");
					DataAssign ();
					assignData = false;
				}
	
	}

	void NameAssign(){ //Rename them
		for (int i=0; i<=46; i++) {
			GameObject square = GameObject.Find("CT_GreenSpiral_" + i.ToString());
			square.name = "CT_" + i.ToString();
		}
		Debug.Log ("Squares are now called CT_#");
	}



	void DataAssign(){	//Assign Edge- and Nook-info.
		for (int i=0; i<=46; i++) {	//Go through all squares
			GameObject square = GameObject.Find("CT_" + i.ToString());
			CT_Aligner aligner = square.GetComponent<CT_Aligner>();

			for (int j=0; j<4; i++){	//Assign Edge-info to square
				Debug.Log (aligner.edges[j]);
				//square.edges[j] = nobrainer[ edgedata[i].Substring(j, 1)];
			}

			for (int j=0; j<4; i++){	//Assign Nook-info to square
				//square.nooks[j] = nobrainer[ edgedata[i].Substring(j, 1)];
				//Debug.Log (square.nooks[j]);
			}
		}
		Debug.Log ("Data values set for all 47 squares");
	}
}
