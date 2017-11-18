using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashWeapon : Weapon {

	public float interval = 0.2f;
	public float speed = 30;
	private float timeElapsed = 0f;

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			GameObject obj =  base.shoot ();
			Vector2 angle = Vector3.Normalize(GetComponent<PlayerController> ().getVerosity ());
			obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
			obj.GetComponent<BulletController>().perticle_size = 2.0f;
			obj.GetComponent<BulletController> ().range = 20;
		}

	}
}