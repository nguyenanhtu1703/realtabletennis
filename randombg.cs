using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombg : MonoBehaviour {

	// Use this for initialization

	public Texture tmp1, tmp2, tmp3;

	public Material a;

	void Start () {
		if (Random.Range (0, 1f) < 0.33f)
			a.mainTexture = tmp1;
		else if (Random.Range (0, 1f) < 0.5f)
			a.mainTexture = tmp2;
		else
			a.mainTexture = tmp3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
