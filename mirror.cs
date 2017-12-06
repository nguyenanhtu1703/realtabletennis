using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour {

	// Use this for initialization

	public GameObject camera, reflextionProbe;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		reflextionProbe.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, transform.position.z * 2 - camera.transform.position.z);
	}
}
