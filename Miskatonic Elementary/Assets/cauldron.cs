using UnityEngine;
using System.Collections;

public class cauldron : MonoBehaviour {

	public string[] inv;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider hitInfo){
		if(hitInfo.tag == "Item"){
			
		}
	}

}
