using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralWeapon : MonoBehaviour {
	public GameObject bullet;
	public GameObject end_perticle;
	public AudioClip audio_shoot;
	public bool shootAudioOn = false;
	public float interval = 0.2f;
	public float speed = 20;
	public Vector2 angle = new Vector2 (0, 1.0f);
	public float angleRate = 30;
	public int damage = 20;
	public int range = 10;
	public float bulletsize = 1;
	public bool clockwise = true;
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
			GameObject obj =  Instantiate (bullet, transform.position, Quaternion.identity);
			obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
			obj.GetComponent<BulletController>().enemybullet = enemybullet;
			obj.GetComponent<BulletController>().damage = damage;
			obj.GetComponent<BulletController>().range = range;
			obj.transform.localScale *= bulletsize;
			timeElapsed = 0.0f;
			int clockwiseornot = (clockwise) ? -1 : 1;
			angle = Quaternion.Euler (0f, 0f, angleRate * clockwiseornot) * angle ;
			if (audio_shoot != null) {
				audioSource.PlayOneShot (audio_shoot, 0.1f);
			}
		}

	}
}
