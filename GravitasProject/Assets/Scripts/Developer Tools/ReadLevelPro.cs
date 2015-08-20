using UnityEngine;
using UnityEditor;

using System.Collections;

using System.Collections.Generic;

public class NilqLevelMaker : EditorWindow {

	private static SceneView.OnSceneFunc onSceneGUIFunc;

	private bool is3D = false;

	private int gridSize;

	private string level;

	private Vector2 scrollPos;

	private Texture2D levelImage;

	private List<string> names = new List<string> ();	
	private List<GameObject> gameObjects = new List<GameObject> ();
	private List<Color> colors = new List<Color> ();

	public static NilqLevelMaker window;

	[MenuItem("Nilq/Nilq - Level Maker")]
	
	public static void ShowWindow () {
		
		window = EditorWindow.GetWindow<NilqLevelMaker> (false, "Level Maker!");
	}

	void OnSceneGUI (SceneView sceneView) {
		
	}

	void OnGUI () {
		
		EditorGUILayout.BeginVertical();
		
		scrollPos = EditorGUILayout.BeginScrollView (scrollPos);

		EditorGUILayout.Space ();

		EditorGUILayout.HelpBox ("www.nilq-folio.com", MessageType.None);

		EditorGUILayout.Space ();

		is3D = EditorGUILayout.Toggle ("Is 3D", is3D);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		levelImage = (Texture2D) EditorGUILayout.ObjectField ("Level Image", levelImage, typeof (Texture2D), false);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		EditorGUILayout.HelpBox ("Add gameobject and color to the list of checking:", MessageType.Info);

		if (GUILayout.Button ("Add to list o' GameObjects/Colors")) {

			names.Add ("");

			colors.Add (new Color ());

			gameObjects.Add (null);
		}

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		for (int i = 0; i < colors.Count; i++) {

			EditorGUILayout.Space ();

			EditorGUILayout.HelpBox ("Name is used for keeping track!", MessageType.Info);

			EditorGUILayout.Space ();

			names [i] =  EditorGUILayout.TextField ("Name: ", names [i]);

			EditorGUILayout.Space ();

			EditorGUILayout.HelpBox ("When a pixel with the color 'A' is found in the level image, the gameobject 'B' will appear at 'A''s coordinate.", MessageType.Info);

			EditorGUILayout.Space ();

			colors [i] = EditorGUILayout.ColorField ("Color (A): " + i, colors [i]);
			gameObjects [i] = (GameObject) EditorGUILayout.ObjectField ("Game Object (B): " + i, gameObjects [i], typeof (GameObject), false);

			EditorGUILayout.Space ();

			EditorGUILayout.Space ();

			if (GUILayout.Button ("Remove")) {

				colors.Remove (colors [i]);

				gameObjects.Remove (gameObjects [i]);
			}

			EditorGUILayout.Space ();
			EditorGUILayout.Space ();
		}

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		if (!(colors.Count <= 0)) {
			
			EditorGUILayout.HelpBox ("This might be dangerous!!!", MessageType.Warning);
			
			if (GUILayout.Button ("Clear list o' GameObjects/Colors")) {

				colors.Clear ();
			}
		}

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		EditorGUILayout.HelpBox ("Check every 'A' pixel in the level image.", MessageType.Info);

		gridSize = EditorGUILayout.IntField ("Grid size (A):", gridSize);

		EditorGUILayout.Space ();
		EditorGUILayout.Space ();

		EditorGUILayout.Space ();

		EditorGUILayout.Space ();

		if (GUILayout.Button ("Make Level")) {

			if (is3D) {

				makeLevel3D ();

			} else {

				makeLevel2D ();
			}
		}
		
		EditorGUILayout.EndScrollView ();
		EditorGUILayout.EndVertical ();
	}

	public void makeLevel3D () {
		
		if (gridSize <= 0) {
			
			gridSize = 1;
		}
		
		for (int x = 0; x < (levelImage.width / gridSize); x++ ) {
			
			for (int y = 0; y < (levelImage.height / gridSize); y++) {
				
				for (int i = 0; i < colors.Count; i++) {
					
					Color pxColor = (Color)levelImage.GetPixel (x * gridSize, y * gridSize);
					
					pxColor = new Color (pxColor.r, pxColor.g, pxColor.b, 0);
					
					if (pxColor.Equals (colors [i])) {
						
						Instantiate (gameObjects [i], new Vector3 (x * gridSize, 0, y * gridSize), Quaternion.Euler (0, 0, 0));
					}
				}
			}
		}
	}

	public void makeLevel2D () {

		if (gridSize <= 0) {

			gridSize = 1;
		}

		for (int x = 0; x < (levelImage.width / gridSize); x++ ) {
			
			for (int y = 0; y < (levelImage.height / gridSize); y++) {
				
				for (int i = 0; i < colors.Count; i++) {

					Color pxColor = (Color)levelImage.GetPixel (x * gridSize, y * gridSize);

					pxColor = new Color (pxColor.r, pxColor.g, pxColor.b, 0);

					if (pxColor.Equals (colors [i])) {

						Instantiate (gameObjects [i], new Vector2 (x * gridSize, y * gridSize), Quaternion.Euler (0, 0, 0));
					}
				}
			}
		}
	}
}