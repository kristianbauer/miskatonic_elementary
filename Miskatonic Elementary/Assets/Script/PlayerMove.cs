using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	private SpriteRenderer ren;
	private Animator anim;
	private Collider item;
	private Vector3 dropPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ren = GetComponentInChildren<SpriteRenderer> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		if(rb.velocity.x > 0){
			ren.flipX = true;
		}
		if(rb.velocity.x < 0){
			ren.flipX = false;
		}

		if (rb.velocity == Vector3.zero) {
			anim.Play ("stand");
		} else {
			anim.Play ("walk");
		}

		if (Input.GetKeyDown (KeyCode.E) && item != null) {
			Debug.Log ("===== item drop");
			item.transform.parent = null;
			item = null;
			dropPosition = transform.position;
		}
	}

	void OnTriggerStay(Collider hitInfo){
		if(hitInfo.tag == "Item"){
			Debug.Log ("===== item stay");
			if (Input.GetKeyDown (KeyCode.E) && item == null && transform.position != dropPosition && rb.velocity == Vector3.zero) {
				Debug.Log ("===== item pickup");
				hitInfo.transform.parent = transform;
				item = hitInfo;
			}
		}
	}
}
