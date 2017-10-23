using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public int speedtilt;
	public int speedkey;
	public Text countText;
	public Text winText;
	public int hitpoint;
	public string nextscene;
	public AudioClip audio_damage;
	public GameObject audio_explosion;
	public GameObject end_perticle;

	private AudioSource audioSource;
	private int count;
	private Rigidbody2D rb2d;

	void Start() {
		audioSource = gameObject.GetComponent<AudioSource> ();
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () {

		if (hitpoint <= 0) {
			Destroy (this.gameObject);
			Instantiate (end_perticle, transform.position, Quaternion.identity);
			Instantiate (audio_explosion, transform.position, Quaternion.identity);
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
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb2d.MovePosition (rb2d.position + movement);
	}

	// 衝突
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive(false);
			count = count + 100;
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Score: " + count.ToString();
		if (count >= 1200) {
			winText.text = "YOU WIN";
		}
	}

	void damage(int damage) {
		hitpoint -= damage;
		audioSource.PlayOneShot (audio_damage, 1.0f);
	}
}
