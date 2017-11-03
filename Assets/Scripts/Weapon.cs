using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject bullet;
	public GameObject end_perticle;
	public int damage = 20;
	public int range = 10;
	public float bulletsize = 1;
	private bool enemybullet = true;
	public AudioSource audioSource;

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
		return obj;
	}
}