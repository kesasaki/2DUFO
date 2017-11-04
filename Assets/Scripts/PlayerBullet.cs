using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : BulletController {

	void Start() {
		tag = "PlayerBullet";
	}

	// 衝突
	public void OnTriggerEnter2D(Collider2D other) {

		// 敵にダメージを与える
		if (other.tag == "Enemy") {
			other.gameObject.SendMessage ("setDamage", damage);
			if (end_perticle != null) {
				Instantiate (end_perticle, transform.position, Quaternion.identity);
			}
		}

		// 敵の弾を消す
		if (other.tag == "EnemyBullet") {
			Destroy (other.gameObject);
		}
	}
}