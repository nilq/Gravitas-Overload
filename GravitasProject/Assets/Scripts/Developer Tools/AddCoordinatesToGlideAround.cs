using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class EnemyXY : EditorWindow {


	[MenuItem ("GameObject/Add GlideAround Coordinates %Q")]
	public static void ShowWindow()
	{
		List<Vector2> coordinates = null;

		try{
			coordinates = Selection.activeGameObject.GetComponent<GlideAround>().coordinateCycle;
		}catch{
			Debug.Log("There is no GlideAround component attatched to this game-object");
		}

		if(coordinates != null){
			coordinates.Add(new Vector2(
				Selection.activeGameObject.transform.position.x, 
				Selection.activeGameObject.transform.position.y));

		}
	}

	void OnGUI()
	{

	}
}
