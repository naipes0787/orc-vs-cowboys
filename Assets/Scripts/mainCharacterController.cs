using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharacterController : MonoBehaviour {
	Rigidbody2D rgb;
	Animator anim;
	public float maxVel = 5f;
	bool toRight = true;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		float v = Input.GetAxis ("Horizontal");
		Vector2 vel = new Vector2 (0, rgb.velocity.y);
		v *= maxVel;
		vel.x = v;
		rgb.velocity = vel;
		anim.SetFloat ("speed", vel.x);
		if (toRight && v < 0) {
			toRight = false;
			Flip ();
		} else if (!toRight && v > 0) {
			toRight = true;
			Flip ();
		}
	}

	void Flip(){
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}
