using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	private Vector3 offset;
	private float defaultsize = 20;

	void Start () {
		offset = transform.position - target.transform.position;
		defaultsize = GetComponent<Camera> ().orthographicSize;
	}

	void FixedUpdate () {
		if (target != null) {
			transform.position = target.transform.position + offset;
			GetComponent<Camera> ().orthographicSize = defaultsize + target.GetComponent<PlayerController>().getVerosity().magnitude / Time.deltaTime / 10;
			//Debug.Log (target.GetComponent<PlayerController>().getVerosity().magnitude);
		}
	}
}
