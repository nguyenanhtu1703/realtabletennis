using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMoveAround : MonoBehaviour {

	// Use this for initialization


	public Transform target;
	public float distance = 10.0f;

	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;

	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;

	private float x = 0.0f;
	private float y = 0.0f;

	int xsign =1;

	public bool stop;

	public void Start () {
		var angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;

		var rotation = Quaternion.Euler(y, x, 0);
		var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

		transform.rotation = rotation;
		transform.position = position;


	}

	public void Stop(){
		stop = true;
	}

	public void Continue(){
		stop = false;
	}

	void LateUpdate () {


		//get the rotationsigns

		if (stop)
			return;

		var forward = transform.TransformDirection(Vector3.up);
		var forward2 = target.transform.TransformDirection(Vector3.up);
		if (Vector3.Dot(forward,forward2) < 0)
			xsign = -1;
		else
			xsign =1;


		foreach(Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Moved) {
				x += xsign * touch.deltaPosition.x * xSpeed *0.02f;
				y -= touch.deltaPosition.y * ySpeed *0.02f;



				var rotation = Quaternion.Euler(y, x, 0);
				var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

				transform.rotation = rotation;
				transform.position = position;
			}
		}
	}

}
