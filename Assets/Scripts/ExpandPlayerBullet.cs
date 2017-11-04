using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPlayerBullet : PlayerBullet {
	public float expandSpeed = 10;

	void Update () {
	    base.Update ();
		GetComponent<Transform> ().localScale *= 1 + expandSpeed / 100;
	}
}
