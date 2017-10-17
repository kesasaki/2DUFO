﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public float interval;
	public GameObject bullet;
	public float speed;
	public Vector2 angle;
	private float timeElapsed = 0f;

	void Start () {	
	}

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			GameObject obj =  Instantiate (bullet, transform.position, Quaternion.identity);
			obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
			timeElapsed = 0.0f;
		}

	}
}