using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization

	public int d = 1;

	public float speed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3 (transform.localPosition.x + speed * d * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
		if (d == 1) {
			if (transform.localPosition.x > transform.parent.GetComponent<RectTransform> ().rect.width  / 2 - GetComponent<RectTransform> ().rect.width ) {
				d = -1;
				transform.localPosition = new Vector3 (transform.parent.GetComponent<RectTransform> ().rect.width / 2 - GetComponent<RectTransform> ().rect.width , transform.localPosition.y, transform.localPosition.z);
			}
		} else {
			if (transform.localPosition.x < - transform.parent.GetComponent <RectTransform> ().rect.width / 2 + GetComponent<RectTransform> ().rect.width ) {
				d = 1;
				transform.localPosition = new Vector3 ( - transform.parent.GetComponent<RectTransform> ().rect.width  / 2 + GetComponent<RectTransform> ().rect.width , transform.localPosition.y, transform.localPosition.z);
			}
		}
	}
}
