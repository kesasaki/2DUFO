using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int hitpoint = 100;
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
			GameObject end = Instantiate (end_perticle, transform.position, Quaternion.identity);
			Instantiate (audio_explosion, transform.position, Quaternion.identity);
			end.gameObject.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
		}
	}

	void setDamage(int damage) {
		hitpoint -= damage;
		audioSource.PlayOneShot (audio_damage, 1.0f);
	}
}
