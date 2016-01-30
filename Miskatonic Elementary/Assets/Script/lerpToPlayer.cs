using UnityEngine;
using System.Collections;

public class lerpToPlayer : MonoBehaviour {

	private Transform player;
	public float zoom;
	public float speed;
	private Camera cam;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player").transform;
		cam = GetComponent<Camera> ();
		zoom = cam.fieldOfView;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.localPosition = new Vector3(Mathf.Lerp(transform.position.x, player.position.x, speed), transform.position.y, Mathf.Lerp(transform.position.z, player.position.z - 12, speed));
		if(Input.GetAxis("Mouse ScrollWheel") != 0){
			//cam.orthographicSize += Input.GetAxis ("Mouse ScrollWheel") / 4;
			zoom += Input.GetAxis ("Mouse ScrollWheel") / 4;


		}
		cam.fieldOfView = Mathf.Clamp(zoom,24,34);
		zoom = cam.fieldOfView;
	}
}