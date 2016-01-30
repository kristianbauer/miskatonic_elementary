using UnityEngine;
using System.Collections;

public class chopTree : MonoBehaviour {

	public int chopNum;
	private GameObject player;
	private PlayerMove playerScript;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		playerScript = player.GetComponentInChildren<PlayerMove> ();

	}

	void OnTriggerStay () {
		if(playerScript.chop){
			chopNum--;
		}
	}
}
