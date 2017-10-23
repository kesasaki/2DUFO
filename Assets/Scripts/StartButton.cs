using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	public string scenename;
	public AudioClip audio_push;
	private AudioSource audioSource;

	void Start () {
		GetComponent<Button>().onClick.AddListener(OnClick);
		audioSource = gameObject.GetComponent<AudioSource> ();
	}

	void Update () {
	}

	public void OnClick() {
		audioSource.PlayOneShot (audio_push, 2.0f);
		SceneManager.LoadScene(scenename);
	}
}
