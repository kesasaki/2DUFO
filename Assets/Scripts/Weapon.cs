using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject bullet;
	public GameObject end_perticle;
	public AudioClip audio_shoot;
	public bool shootAudioOn = false;
	public int damage = 20;
	public int range = 10;
	public float speed = 30;
	public float bulletsize = 1;
	private bool enemybullet = true;
	private AudioSource audioSource;

	public void Start () {
		if (tag == "Player") {
			enemybullet = false;
		}
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	public GameObject shoot() {
		GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
		obj.GetComponent<BulletController> ().enemybullet = enemybullet;
		obj.GetComponent<BulletController> ().damage = damage;
		obj.GetComponent<BulletController> ().range = range;
		obj.GetComponent<BulletController> ().end_perticle = end_perticle;
		obj.transform.localScale *= bulletsize;
		if (audio_shoot != null) {
			audioSource.PlayOneShot (audio_shoot, 0.1f);
		}
		return obj;
	}
}