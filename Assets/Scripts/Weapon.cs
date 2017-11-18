using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject bullet;
	public GameObject hit_perticle;
	public int damage = 20;
	public int range = 10;
	public float bulletsize = 1;
	public AudioSource audioSource;
	public bool available = true;

	public void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	public GameObject shoot() {
		if (!available) {
			return null;
		}
		GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
		obj.GetComponent<BulletController> ().damage = damage;
		obj.GetComponent<BulletController> ().range = range;
		obj.GetComponent<BulletController> ().end_perticle = hit_perticle;
		obj.transform.localScale *= bulletsize;
		return obj;
	}
}