using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralWeapon : MonoBehaviour {
	public float interval;
	public GameObject bullet;
	public GameObject end_perticle;
	public float speed;
	public Vector2 angle;
	public float angleRate;
	public int damage;
	public int range;
	public float bulletsize;
	public bool clockwise;
	private float timeElapsed = 0f;
	private bool enemybullet = true;
	public AudioClip audio_shoot;
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
			audioSource.PlayOneShot (audio_shoot, 1.0f);
		}

	}
}
