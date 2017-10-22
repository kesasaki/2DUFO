using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour {

	void Start () {

		AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
		Destroy (this.gameObject, audioSource.clip.length);
	}

	void Update () {
		
	}
}
