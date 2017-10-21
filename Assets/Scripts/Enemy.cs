using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int hitpoint;
	public Text winText;
	public GameObject end_perticle;

	void Start () {
		
	}

	void Update () {
		if (hitpoint <= 0) {
			Destroy (this.gameObject);
		}
	}

	void damage(int damage) {
		hitpoint -= damage;
	}

	void OnDestroy() {
		if (end_perticle != null) {
			Instantiate (end_perticle, transform.position, Quaternion.identity);
		}
		winText.text = "YOU WIN";
	}
}
