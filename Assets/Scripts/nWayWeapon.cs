﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nWayWeapon : MonoBehaviour {
	public float interval;
	public GameObject bullet;
	public GameObject target;
	public GameObject end_perticle;
	public float speed;
	public float anglerange;
	public int n;
	public int damage;
	public int range;
	public float bulletsize;
	public AudioClip audio_shoot;
	private float timeElapsed = 0f;
	private bool enemybullet = true;
	private AudioSource audioSource;


	void Start () {
		if (tag == "Player") {
			enemybullet = false;
		}
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			if (target != null) {
				Vector2 angle = target.transform.position - transform.position;
				angle.Normalize ();
				if (n == 1) {
					GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
					obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
					obj.GetComponent<BulletController> ().enemybullet = enemybullet;
					obj.GetComponent<BulletController> ().damage = damage;
					obj.GetComponent<BulletController> ().range = range;
					obj.GetComponent<BulletController> ().end_perticle = end_perticle;
					obj.transform.localScale *= bulletsize;
					timeElapsed = 0.0f;
					audioSource.PlayOneShot (audio_shoot, 0.1f);
				} else {
					for (int i = 0; i < n; i++) {
						GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
						Vector2 thisangle = Quaternion.Euler (0f, 0f, anglerange * ((float)i / (n - 1) - 0.5f)) * angle;
						obj.GetComponent<Rigidbody2D> ().velocity = speed * thisangle;
						obj.GetComponent<BulletController> ().enemybullet = enemybullet;
						obj.GetComponent<BulletController> ().damage = damage;
						obj.GetComponent<BulletController> ().range = range;
						obj.GetComponent<BulletController> ().end_perticle = end_perticle;
						obj.transform.localScale *= bulletsize;
						timeElapsed = 0.0f;
						audioSource.PlayOneShot (audio_shoot, 0.1f);
					}
				}
			}
		}
	}
}
