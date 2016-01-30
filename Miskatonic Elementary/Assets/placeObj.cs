using UnityEngine;
using System.Collections;

public class placeObj : MonoBehaviour {

	public GameObject prefab;
	private GameObject container;
	private float radius;
	public int totalNum;
	private int currentNum;
	public Vector2 plane;
	private Vector3 randomPos;



	// Use this for initialization
	void Start () {
		currentNum = 0;
		container = new GameObject ("Container");
		radius = prefab.GetComponent<SphereCollider> ().radius;

		while(currentNum < totalNum){
			randomPos = new Vector3 (Random.Range(-plane.x / 2 , plane.x / 2),0,Random.Range(-plane.y / 2 , plane.y / 2));
			if(checkPos(randomPos,radius)){
				spawnObj (currentNum, randomPos);
				currentNum++;
			}
		}
	}

	void spawnObj (int _i, Vector3 ran) {
		GameObject temp = Instantiate(prefab) as GameObject;
		temp.transform.parent = container.transform;
		temp.transform.position = ran;
		temp.name = name + _i;
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
