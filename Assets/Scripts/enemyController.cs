using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {
	public float vel = -1f;
	Rigidbody2D rgb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rgb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
		Vector2 v = new Vector2 (vel, rgb.velocity.y);
		rgb.velocity = v;
		if ((anim.GetCurrentAnimatorStateInfo (0).IsName ("walking")) && 
				(Random.value < (1f / (60f * 3f)))) {
			anim.SetTrigger ("aim");
		} else if (anim.GetCurrentAnimatorStateInfo (0).IsName ("aiming")){
			if(Random.value < 1f / 3f) {
				anim.SetTrigger ("shoot");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Flip ();
	}

	void Flip(){
		vel *= -1;
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;
	}
}
