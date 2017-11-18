using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : Weapon {

	public float interval = 0.2f;
	public float bullet_speed = 100;
	public int walk_speed = 100;
	private float timeElapsed = 0f;
	private int original_max_speed;

	void Start() {
		base.Start ();
		original_max_speed = GetComponent<PlayerController> ().max_speed;
	}

	void Update () {

		// チャージ開始　タッチ開始 or space key ボタンダウン
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= interval) {
			timeElapsed = 0.0f;
			if (Input.GetKey (KeyCode.Space) || (Input.touchCount > 0)) {
				GameObject obj = base.shoot ();
				Vector3 angle;
				if (GetComponent<PlayerController> ().getVerosity ().magnitude != 0) {
					angle = Vector3.Normalize (GetComponent<PlayerController> ().getVerosity ());
				} else {
					angle = new Vector3 (0, 1.0f, 0);
				}
				obj.GetComponent<Rigidbody2D> ().velocity = angle * bullet_speed;
				obj.transform.rotation = Quaternion.Euler (0, 0, getRotate (angle) - 90);
				GetComponent<PlayerController> ().max_speed = walk_speed;
			} else {
				GetComponent<PlayerController> ().max_speed = original_max_speed;
			}
		}
	}

	float getRotate(Vector2 angle) {
		float rot = Mathf.Atan2 (angle.y, angle.x) * 180 / Mathf.PI;
		if(rot > 180) rot-= 360;
		if(rot <-180) rot+= 360;
		return rot;
	}
}