using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class Populate : EditorWindow {

	static GameObject prefab;
	static GameObject container;
	static float radius;
	static int totalNum;
	static int currentNum;
	static Vector2 plane;
	static Vector3 randomPos;
	static int tryNum;
	static int passes = 50;



	// Use this for initialization

	[MenuItem("Custom/Populate")]
	static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(Populate));
		//Defaults();
	}

	public void OnGUI(){
		if (GUILayout.Button("Reset"))
		{
			Default();
		}
		prefab = EditorGUILayout.ObjectField(prefab, typeof(GameObject), true) as GameObject;
		totalNum =  EditorGUILayout.IntField("Number of Objects:", Mathf.Abs(totalNum));
		passes =  EditorGUILayout.IntField("Number of Passes:", Mathf.Clamp(passes,0,100));
		plane = EditorGUILayout.Vector2Field ("Plane Size:",plane);
		if (GUILayout.Button("Create Field"))
		{
			Spawn();
		}

	}

	static void Default(){
		totalNum = 300;
		passes = 50;
		plane = new Vector2(50,50);
	}


	static void Spawn () {
		currentNum = 0;
		tryNum = 0;
		container = new GameObject ("Container");
		radius = prefab.GetComponent<SphereCollider> ().radius;

		while(currentNum < totalNum){
			tryNum++;
			randomPos = new Vector3 (Random.Range(-plane.x , plane.x),0,Random.Range(-plane.y , plane.y));
			if(checkPos(randomPos,radius)){
				spawnObj (currentNum, randomPos);
			}
			if(tryNum > totalNum * passes){
				break;
			}
		}
		Debug.Log ("We created " + currentNum + " New Objects!");
	}

	static void spawnObj (int _i, Vector3 ran) {
		currentNum++;
		GameObject temp = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
		temp.transform.parent = container.transform;
		temp.transform.position = ran;
		temp.name = prefab.name + _i;
	}

	static bool checkPos(Vector3 pos, float rad){
		Collider[] hitColliders = Physics.OverlapSphere(pos, rad);
		if (hitColliders.Length >= 1) {
			return false;
		} else {
			return true;
		}
	}

}
