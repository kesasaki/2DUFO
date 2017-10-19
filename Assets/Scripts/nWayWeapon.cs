using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nWayWeapon : MonoBehaviour {
	public float interval;
	public GameObject bullet;
	public GameObject target;
	public float speed;
	public float anglerange;
	public int n;
	public int damage;
	public int range;
	public float bulletsize;
	private float timeElapsed = 0f;
	private bool enemybullet = true;


	void Start () {
		if (tag == "Player") {
			enemybullet = false;
		}
	}

	void Update () {
		timeElapsed += Time.deltaTime;
		if(timeElapsed >= interval) {
			Vector2 angle = target.transform.position - transform.position;
			angle.Normalize ();
			if (n == 1) {
				GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
				obj.GetComponent<Rigidbody2D> ().velocity = angle * speed;
				obj.GetComponent<BulletController>().enemybullet = enemybullet;
				obj.GetComponent<BulletController>().damage = damage;
				obj.GetComponent<BulletController>().range = range;
				obj.transform.localScale *= bulletsize;
				timeElapsed = 0.0f;
			} else {
				for (int i = 0; i < n; i++) {
					GameObject obj = Instantiate (bullet, transform.position, Quaternion.identity);
					Vector2 thisangle = Quaternion.Euler (0f, 0f, anglerange * ((float)i / (n - 1) - 0.5f)) * angle;
					obj.GetComponent<Rigidbody2D> ().velocity = speed * thisangle;
					obj.GetComponent<BulletController>().enemybullet = enemybullet;
					obj.GetComponent<BulletController>().damage = damage;
					obj.GetComponent<BulletController>().range = range;
					obj.transform.localScale *= bulletsize;
					timeElapsed = 0.0f;
				}
			}
		}
	}
}
