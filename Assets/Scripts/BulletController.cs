using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public int damage = 30;
	public int range = 100;
	public GameObject end_perticle;
	public int hitpoint = 10;
	private int distance = 0;

	public void Update() {

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

	public void setDamage(int damage) {
		hitpoint -= damage;
	}
}
