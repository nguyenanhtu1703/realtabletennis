using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadsprite : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Image> ().sprite = Resources.Load ("b" + (PlayerPrefs.GetInt("ball")  + 1).ToString(), typeof(Sprite))as Sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
