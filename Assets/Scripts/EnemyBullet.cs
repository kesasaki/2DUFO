using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : BulletController {

	void Start() {
		tag = "EnemyBullet";
	}

	// 衝突
	public void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.gameObject.SendMessage ("setDamage", damage);
			if (end_perticle != null) {
				GameObject end = Instantiate (end_perticle, transform.position, Quaternion.identity);
				end.gameObject.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
			}
			Destroy (this.gameObject);
		}
	}
}
