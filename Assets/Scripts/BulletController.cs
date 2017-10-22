using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public int damage;
	public bool enemybullet;
	public int range = 100;
	public GameObject end_perticle;
	private int distance = 0;

	void Start() {
	}

	void Update() {
		if (distance > range) {
			Destroy (this.gameObject);
		}
		distance += 1;
	}

	// 衝突
	void OnTriggerEnter2D(Collider2D other) {
		if ((enemybullet && other.tag == "Player") || (!enemybullet && other.tag == "Enemy")) {
			other.gameObject.SendMessage ("damage", damage);
			if (end_perticle != null) {
				Instantiate (end_perticle, transform.position, Quaternion.identity);
			}
			Destroy (this.gameObject);
		}
	}
}
