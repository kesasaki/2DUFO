using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	public string scenename;

	void Start () {
		GetComponent<Button>().onClick.AddListener(OnClick);
	}

	void Update () {
	}

	public void OnClick() {
		Debug.Log (scenename);
		SceneManager.LoadScene(scenename);
	}
}
