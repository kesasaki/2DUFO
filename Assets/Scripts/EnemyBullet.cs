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
				Instantiate (end_perticle, transform.position, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
	}
}
