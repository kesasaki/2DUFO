using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralWeapon : Weapon {

	public float interval = 0.2f;
	public Vector2 angle = new Vector2 (0, 1.0f);
	public float angleRate = 30;
	public float speed = 30;
	public bool clockwise = true;
	private float timeElapsed = 0f;

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			GameObject obj =  base.shoot ();
			obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
			timeElapsed = 0.0f;
			int clockwiseornot = (clockwise) ? -1 : 1;
			angle = Quaternion.Euler (0f, 0f, angleRate * clockwiseornot) * angle ;
		}

	}
}
