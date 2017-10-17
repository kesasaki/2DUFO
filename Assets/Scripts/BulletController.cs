using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {

	public int damage;
	public Vector2 movement;
	public bool enemybullet;


	private int count;
	private Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {
		rb2d.MovePosition (rb2d.position + movement);
	}

	// 衝突
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("aaaa");
	}

}
