using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandBullet : BulletController {

	void FixedUpdate () {
		GetComponent<Transform> ().localScale *= 1.06f;
	}
}
