using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testting : MonoBehaviour {

	// Use this for initialization

	public GameObject a, b, c, d;

	void Start () {
		a.transform.rotation = Quaternion.Euler (new Vector3(0, 180, 0));
		b.transform.rotation = Quaternion.Euler (new Vector3(0, 180, 0));
		c.transform.rotation = Quaternion.Euler (new Vector3(0, 180, 0));
		d.transform.rotation = Quaternion.Euler (new Vector3(0, 180, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
