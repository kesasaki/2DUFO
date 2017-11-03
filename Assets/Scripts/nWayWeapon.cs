using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nWayWeapon : Weapon {

	public GameObject target;
	public float interval = 0.2f;
	public float anglerange = 30;
	public float speed = 30;
	public int n = 3;
	private float timeElapsed = 0f;

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			if (target != null) {
				Vector2 angle = target.transform.position - transform.position;
				angle.Normalize ();
				if (n == 1) {
					GameObject obj = base.shoot ();
					obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
					timeElapsed = 0.0f;
				} else {
					for (int i = 0; i < n; i++) {
						GameObject obj = base.shoot ();
						Vector2 thisangle = Quaternion.Euler (0f, 0f, anglerange * ((float)i / (n - 1) - 0.5f)) * angle;
						obj.GetComponent<Rigidbody2D> ().velocity = speed * thisangle;
						timeElapsed = 0.0f;
					}
				}
			}
		}
	}
}
