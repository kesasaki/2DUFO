using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoWeapon : Weapon {
	public AudioClip audio_shoot;

	void Update () {

		// タッチ
		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Ended){
				base.shoot ();
				base.audioSource.PlayOneShot (audio_shoot, 1.0f);
			}
		}
	}
}
