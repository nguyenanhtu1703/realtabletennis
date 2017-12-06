using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingmanager : MonoBehaviour {

	// Use this for initialization

	public static loadingmanager instance = null;

	public GameObject G1, G2;

	void Start () {
		if (instance == null)
			instance = this;
		else {
			Destroy (this.gameObject);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	public void Active(){
		G1.gameObject.SetActive (true);
		//G2.gameObject.SetActive (true);
		//G2.GetComponent<TweenSequence> ().BeginSequence ();
	}

	public void Deactive(){
		G1.gameObject.SetActive (false);
		//G2.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
