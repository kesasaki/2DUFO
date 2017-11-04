using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandPlayerBullet : PlayerBullet {

	void Update () {
	    base.Update ();
		GetComponent<Transform> ().localScale *= 1.1f;
	}
}
