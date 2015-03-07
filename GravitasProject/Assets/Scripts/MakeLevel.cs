using UnityEngine;

using System.Collections;
using System.Text;
using System.IO;  

/*
	A BIT HARD CODED... SORRY!
*/

public class MakeLevel : MonoBehaviour {

	private StreamReader fileReader;

	private string [] loadedLines;
	private string [] finalLines;
	private string [] lineData;

	public GameObject block01;

	void Awake () {
	
		loadFile ("level.txt");
		splitFile ();
	}

	private bool loadFile (string path) {

		try {

			string line;

			fileReader = new StreamReader (path, Encoding.Default);

			using (fileReader) {

				do {

					line = fileReader.ReadLine ();
					
					if (line != null) {

						loadedLines = line.Split ('\n');
					}
				}

				while (line != null);

				fileReader.Close();

				return true;
			}
		} catch {

			print ("Couldn't load file... Maybe other stuff, how should I know, I'm just a 'try-catch'.");

			return false;
		}
	}

	void splitFile () {

		for (int i = 0; i < loadedLines.Length; i++) {
		
			finalLines = loadedLines [i].Split (';');

			for (int j = 0; j < finalLines.Length; j++) {
			
				lineData = finalLines [j].Split (',');

				for (int k = 0; k < (lineData.Length / 2); k++) {

					Instantiate (block01, new Vector2 (int.Parse (lineData [j]), int.Parse (lineData [j + 1])), Quaternion.identity);
				}
			}
		}
	}
}