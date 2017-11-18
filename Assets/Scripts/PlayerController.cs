using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int speedtilt;
	public int speedkey;
	public int hitpoint;
	public AudioClip audio_damage;
	public AudioClip audio_explosion;
	public GameObject end_perticle;
	public int max_speed = 500;

	private AudioSource audioSource;
	private Rigidbody2D rb2d;
	private Vector2 movement;
	private bool end_flag = false;

	void Start() {
		audioSource = gameObject.GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate () {

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
		// 加速度
		float moveHorizontal = Input.acceleration.x * speedtilt;
		float moveVertical = Input.acceleration.y * speedtilt;
		// キー
		float axisHorizontal = Input.GetAxis ("Horizontal") * speedkey;
		float axisVertical = Input.GetAxis ("Vertical") * speedkey;
		// キー優先
		if (axisHorizontal != 0 || axisVertical != 0) {
			moveHorizontal = axisHorizontal;
			moveVertical = axisVertical;
		}
		movement = new Vector2 (moveHorizontal, moveVertical);
		if (movement.magnitude > (float)max_speed / 100) {
			movement.Normalize ();
			movement *= ((float)max_speed / 100);
		}
		rb2d.MovePosition (rb2d.position + movement);
	}

	void setDamage(int damage) {
		hitpoint -= damage;
		audioSource.PlayOneShot (audio_damage, 1.0f);
	}

	public Vector2 getVerosity() {
		return movement;
	}
}
