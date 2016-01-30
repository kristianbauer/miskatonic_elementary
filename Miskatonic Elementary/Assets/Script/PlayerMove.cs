using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	private SpriteRenderer ren;
	public bool chop;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		ren = GetComponentInChildren<SpriteRenderer> ();
		chop = false;
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
			if (Input.GetKeyDown (KeyCode.E)) {
				chop = true;
			}
		} else {
			anim.Play ("walk");
		}
			

	}
}
