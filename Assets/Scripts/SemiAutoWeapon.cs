using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutoWeapon : Weapon {
	public int expand_max = 100;
	public AudioClip audio_shoot;

	private float starttime = 0;

	void Update () {

		// チャージ開始　タッチ開始 or space key ボタンダウン
		if (Input.GetKeyDown (KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)) {
			starttime = Time.time;
		}

		// 弾を撃つ　タッチ終了 or space key ボタンアップ
		if (Input.GetKeyUp (KeyCode.Space) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)){
			GameObject obj = base.shoot ();
			obj.transform.parent = this.transform;
			obj.GetComponent<ExpandPlayerBullet> ().range = Mathf.Min(expand_max / 2, (int)((Time.time - starttime) * 100)) ;
			Debug.Log (obj.GetComponent<BulletController> ().range);
			base.audioSource.PlayOneShot (audio_shoot, 1.0f);
		}
	}
}
