using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

	public Text countText;
	public Text winText;
	public string nextscene;
	public AudioClip audio_win;
	public AudioClip audio_lose;

	private bool end_flag=false;
	private AudioSource audioSource;

	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		winText.text = "";
		
	}

	void Update () {
		int enemynum =  GameObject.FindGameObjectsWithTag("Enemy").Length;
		int playernum = GameObject.FindGameObjectsWithTag("Player").Length;
		countText.text = "Enemy: " + enemynum.ToString();
		if (!end_flag && enemynum <= 0) {
			winText.text = "YOU WIN";
			Invoke("goNextScene", audio_win.length);
			audioSource.PlayOneShot (audio_win, 1.0f);
			end_flag = true;
		}
		if (!end_flag && playernum <= 0) {
			winText.text = "YOU LOSE";
			Invoke("goNextScene", audio_lose.length);
			audioSource.PlayOneShot (audio_lose, 1.0f);
			end_flag = true;
		}
	}

	void goNextScene() {
		SceneManager.LoadScene(nextscene);
	}
}
