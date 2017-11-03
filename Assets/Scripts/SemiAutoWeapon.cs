using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoWeapon : MonoBehaviour {
	public GameObject bullet;
	public GameObject end_perticle;
	public AudioClip audio_shoot;
	public bool shootAudioOn = false;
	public int damage = 20;
	public int range = 10;
	public float bulletsize = 1;
	private bool enemybullet = true;
	private AudioSource audioSource;

	void Start () {
		if (tag == "Player") {
			enemybullet = false;
		}
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {

		// タッチされた
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Ended){
				shoot ();
			}
		}
	}

	void shoot() {
		GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
		obj.GetComponent<BulletController> ().enemybullet = enemybullet;
		obj.GetComponent<BulletController> ().damage = damage;
		obj.GetComponent<BulletController> ().range = range;
		obj.transform.localScale *= bulletsize;
		if (audio_shoot != null) {
			audioSource.PlayOneShot (audio_shoot, 0.1f);
		}
	}
}
