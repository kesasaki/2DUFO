using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int hitpoint;
	public Text winText;

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
		winText.text = "YOU WIN";
	}
}
