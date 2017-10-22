﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int hitpoint;
	public Text winText;
	public GameObject end_perticle;
	public GameObject audio_explosion;
	public AudioClip audio_damage;
	private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		if (hitpoint <= 0) {
			Destroy (this.gameObject);
			Instantiate (end_perticle, transform.position, Quaternion.identity);
			Instantiate (audio_explosion, transform.position, Quaternion.identity);
			winText.text = "YOU WIN";
		}
	}

	void damage(int damage) {
		hitpoint -= damage;
		audioSource.PlayOneShot (audio_damage, 1.0f);
	}

	void OnDestroy() {
	}
}
