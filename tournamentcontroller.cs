using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tournamentcontroller : MonoBehaviour {

	// Use this for initialization
	public static tournamentcontroller instance = null;

	public int[] cs, stars;

	public int[] r2, r3;

	public int rankFinal;

	void Awake(){
		loadingmanager.instance.Deactive ();
		if (instance == null)
			instance = this;
		else {
			Destroy (this.gameObject);
			return;
		}
		DontDestroyOnLoad (this.gameObject);
	}

	public void Init(){
		cs = new int[8]{ GameManager.instance.p1Country, 1, 2, 3, 4, 5, 6, 7 };
		r2 = new int[4];
		r3 = new int[4];
		if (GameManager.instance.kindOfTournament == 1) {
			stars = new int[8]{ 0, 0, 0, 0, 1, 1, 2, 2 };
		} else if (GameManager.instance.kindOfTournament == 2) {
			stars = new int[8]{ 0, 0, 2, 1, 1, 2, 2, 3 };
		} else stars = new int[8]{ 0, 1, 2, 2, 2, 2, 3, 3 };
		int i;
		for (i = 1; i <= 7; i++)
			if (cs [0] == cs [i])
				break;
		for (int j = i; j <= 7; j++)
			cs [j] = j + 1;
	}

	void Start () {
		loadingmanager.instance.Deactive ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
