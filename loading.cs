﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.Landscape;
		Application.LoadLevel (1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
