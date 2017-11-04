using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public int hitpoint = 100;
	public GameObject end_perticle;
	public AudioClip audio_damage;
	public AudioClip audio_explosion;
	private AudioSource audioSource;
	private bool end_flag = false;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
		if (hitpoint <= 0 && !end_flag) {
			GameObject end = Instantiate (end_perticle, transform.position, Quaternion.identity);
			end.gameObject.transform.localScale = new Vector3 (6.0f, 6.0f, 6.0f);
			audioSource.PlayOneShot (audio_explosion, 1.0f);
			Destroy (this.gameObject, audio_explosion.length);
			gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = "Unvisible";
			gameObject.GetComponent<Rigidbody2D> ().simulated = false;
			gameObject.GetComponent<Weapon> ().available = false;
			end_flag = true;
		}
	}

	void setDamage(int damage) {
		hitpoint -= damage;
		audioSource.PlayOneShot (audio_damage, 1.0f);
	}
}
