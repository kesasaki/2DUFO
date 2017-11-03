using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public int damage = 30;
	public bool enemybullet = true;
	public int range = 10;
	public GameObject end_perticle;
	public int hitpoint = 10;
	private int distance = 0;

	void Start() {
	}

	void Update() {

		// range 進んだら消える
		if (distance > range) {
			Destroy (this.gameObject);
		}
		distance += 1;

		// hitpoint 削られたら消える
		if (hitpoint <= 0) {
			if (end_perticle != null) {
				Instantiate (end_perticle, transform.position, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
	}

	// 衝突
	void OnTriggerEnter2D(Collider2D other) {
		if ((enemybullet && other.tag == "Player") || (!enemybullet && other.tag == "Enemy")) {
			other.gameObject.SendMessage ("setDamage", damage);
			if (end_perticle != null) {
				Instantiate (end_perticle, transform.position, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
	}

	public void setDamage(int damage) {
		hitpoint -= damage;
	}
}
