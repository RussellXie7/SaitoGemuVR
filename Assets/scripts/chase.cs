using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {

    public Transform player;
	public GameObject crawler;
	static Animator anim;

	// Use this for initialization
	void Start () {
		anim = crawler.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

        anim = crawler.GetComponent<Animator>();

        Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < 20  && angle<180 ) {
			direction.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 1) {

				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);

			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);
			}
		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
		}
	}
}
