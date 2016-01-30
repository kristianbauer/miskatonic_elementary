using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	private SpriteRenderer ren;
	public bool pickup;
	private Animator anim;
	private Collider item;
	private bool canPickup;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ren = GetComponentInChildren<SpriteRenderer> ();
		pickup = false;
		anim = GetComponentInChildren<Animator> ();
		canPickup = true;
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
			
		if (Input.GetKeyDown (KeyCode.E) && pickup == true) {
			item.transform.parent = null;
			pickup = false;
			item = null;
		}
	}

	void OnTriggerStay(Collider hitInfo){
		if(hitInfo.tag == "Item"){
			if (Input.GetKeyDown (KeyCode.E) && pickup == false && canPickup == true) {
				hitInfo.transform.parent = transform;
				pickup = true;
				item = hitInfo;
				canPickup = false;
			}
		}
	}

	void OnTriggerExit(){
		canPickup = true;
	}

}
