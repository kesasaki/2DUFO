using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public Text countText;
	public Text winText;
	public Text playerHitpoint;
	public string nextscene;
	public AudioClip audio_win;
	public AudioClip audio_lose;
	public GameObject background;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject player;
	public float enemyLevelUpTime;

	private float timeElapsed;
	private int enemy_num_max = 3;
	private bool end_flag=false;
	private AudioSource audioSource;
	private int point = 10;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		winText.text = "";
		for (int i = 0; i < enemy_num_max; i++) {
			initiateEnemy ();
		}
	}

	void Update () {
		int enemynum =  GameObject.FindGameObjectsWithTag("Enemy").Length;
		int playernum = GameObject.FindGameObjectsWithTag("Player").Length;

		// 敵全滅
		if (!end_flag && enemynum <= 0) {
			winText.text = "YOU WIN";
			Invoke("goNextScene", audio_win.length);
			audioSource.PlayOneShot (audio_win, 1.0f);
			end_flag = true;
		}

		// プレイヤー死亡
		if (player == null) {
			if (!end_flag) {
				winText.text = "YOU LOSE";
				Invoke ("goNextScene", audio_lose.length);
				audioSource.PlayOneShot (audio_lose, 1.0f);
				end_flag = true;
				playerHitpoint.text = "hitpoint: " + 0;
			}

		// プレイヤー生存
		} else {
			playerHitpoint.text = "hitpoint: " + player.GetComponent<PlayerController> ().hitpoint;
		}

		// 敵が減る
		if (enemynum < enemy_num_max) {
			initiateEnemy ();
		}

		// 敵の数が増える
		if(timeElapsed >= enemyLevelUpTime) {
			enemy_num_max ++ ;
			timeElapsed = 0.0f;
			Debug.Log ("Enemy num Up !!");
		}
		timeElapsed += Time.deltaTime;

		// 現在のステータス表示
		countText.text = "point: " + point.ToString();
	}

	void goNextScene() {
		SceneManager.LoadScene(nextscene);
	}

	void initiateEnemy() {
		GameObject obj = Instantiate (
			enemy1,
			new Vector3 (
				Random.Range (
					background.GetComponent<SpriteRenderer> ().bounds.size.x / 2 * (-1),
					background.GetComponent<SpriteRenderer> ().bounds.size.x / 2),
				Random.Range (
					background.GetComponent<SpriteRenderer> ().bounds.size.y / 2 * (-1),
					background.GetComponent<SpriteRenderer> ().bounds.size.y / 2),
				0),
			Quaternion.identity);
		obj.GetComponent<nWayWeapon> ().target = player;
	}
}
