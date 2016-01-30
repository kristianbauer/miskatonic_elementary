using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveFactor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveVector = new Vector3 (Input.GetAxisRaw ("Horizontal") * moveFactor, Input.GetAxisRaw ("Vertical") * moveFactor, 0);
		this.transform.position += moveVector;
	}
}
