using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tournamentcontrollerui : MonoBehaviour {

	// Use this for initialization

	public GameObject[] r1, r2, r3;
	public Text statusTxt, statusMatchTxt;
	public GameObject vsPanel;
	public Image p1Flag, p2Flag, tournamentImage;
	public Sprite[] whichTournamentImage;
	public GameObject quitTournamentPanel;
	public GameObject g1, g2, g3, g4, g5, g6;
	public Image t1, t2, t3, t4;


	public void QuitTournament(){
		if (GameManager.instance.tournamentRound >= 4 || (GameManager.instance.tournamentRound == 2 && tournamentcontroller.instance.r2 [0] != 0)) {
			Application.LoadLevel (1);
		} else {
			quitTournamentPanel.gameObject.SetActive (true);
		}
	}

	void Start () {
		//if(AudioManager.instance != null && AudioManager.instance.SFX.isPlaying == false) AudioManager.instance.SFX.Play ();

		t1.gameObject.SetActive (false);

		t2.gameObject.SetActive (false);

		t3.gameObject.SetActive (false);

		t4.gameObject.SetActive (false);

		g1.gameObject.SetActive (false);

		g2.gameObject.SetActive (false);

		g3.gameObject.SetActive (false);

		g4.gameObject.SetActive (false);

		g5.gameObject.SetActive (false);

		g6.gameObject.SetActive (false);

		tournamentImage.sprite = whichTournamentImage [GameManager.instance.kindOfTournament - 1];
		if (GameManager.instance.tournamentRound == 1) tournamentcontroller.instance.Init ();	
		if (GameManager.instance.tournamentRound >= 1) {
			p1Flag.sprite = Resources.Load (tournamentcontroller.instance.cs [0].ToString (), typeof(Sprite)) as Sprite;
			p2Flag.sprite = Resources.Load (tournamentcontroller.instance.cs [1].ToString (), typeof(Sprite)) as Sprite;
			GameManager.instance.p1Country = tournamentcontroller.instance.cs [0];
			GameManager.instance.p2Country = tournamentcontroller.instance.cs [1];
			GameManager.instance.level = tournamentcontroller.instance.stars [1];
			statusMatchTxt.text = "Quarter Finals";

			t1.gameObject.SetActive (true);

			t2.gameObject.SetActive (false);

			t3.gameObject.SetActive (false);

			t4.gameObject.SetActive (false);

			for (int i = 0; i <= 7; i++) {
				r1 [i].transform.GetChild (0).GetComponent<Image> ().sprite = Resources.Load (tournamentcontroller.instance.cs [i].ToString (), typeof(Sprite)) as Sprite;
				for(int j = 1; j <= 3; j++){
					r1 [i].transform.GetChild (0).transform.GetChild(0).transform.GetChild(j - 1).gameObject.SetActive(false);
				}
				for(int j = 1; j <= tournamentcontroller.instance.stars [i]; j++){
					r1 [i].transform.GetChild (0).transform.GetChild(0).transform.GetChild(j - 1).gameObject.SetActive(true);
				}
			}
		} 
		if (GameManager.instance.tournamentRound >= 2) {
			g1.gameObject.SetActive (true);
			g2.gameObject.SetActive (true);
			p1Flag.sprite = Resources.Load (tournamentcontroller.instance.cs [0].ToString (), typeof(Sprite)) as Sprite;
			p2Flag.sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r2 [1]].ToString (), typeof(Sprite)) as Sprite;
			GameManager.instance.p1Country = tournamentcontroller.instance.cs [0];
			GameManager.instance.p2Country = tournamentcontroller.instance.cs[tournamentcontroller.instance.r2 [1]];
			GameManager.instance.level = tournamentcontroller.instance.stars[tournamentcontroller.instance.r2 [1]];
			statusMatchTxt.text = "Semi Finals";

			t1.gameObject.SetActive (false);

			t2.gameObject.SetActive (true);

			t3.gameObject.SetActive (false);

			t4.gameObject.SetActive (false);

			for (int i = 0; i <= 3; i++) {
				r2 [i].transform.GetChild (0).GetComponent<Image> ().sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r2 [i]].ToString (), typeof(Sprite)) as Sprite;
				for(int j = 1; j <= 3; j++){
					r2 [i].transform.GetChild (0).transform.GetChild(0).transform.GetChild(j - 1).gameObject.SetActive(false);
				}
				for(int j = 1; j <= tournamentcontroller.instance.stars [tournamentcontroller.instance.r2 [i]]; j++){
					r2 [i].transform.GetChild (0).transform.GetChild(0).transform.GetChild(j - 1).gameObject.SetActive(true);
				}
			}
		} else {
			for (int i = 0; i <= 3; i++) 
				r2 [i].transform.GetChild (0).gameObject.SetActive (false);
		}
		if (GameManager.instance.tournamentRound >= 3) {
			g3.gameObject.SetActive (true);
			g4.gameObject.SetActive (true);
			g5.gameObject.SetActive (true);
			g6.gameObject.SetActive (true);
			if (tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [0]] == tournamentcontroller.instance.cs[0]) {
				p1Flag.sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [0]].ToString (), typeof(Sprite)) as Sprite;
				p2Flag.sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [1]].ToString (), typeof(Sprite)) as Sprite;
				GameManager.instance.p1Country = tournamentcontroller.instance.cs [0];
				GameManager.instance.p2Country = tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [1]];
				GameManager.instance.level = tournamentcontroller.instance.stars[tournamentcontroller.instance.r3 [1]];
				statusMatchTxt.text = "Finals";

				t1.gameObject.SetActive (false);

				t2.gameObject.SetActive (false);

				t3.gameObject.SetActive (false);

				t4.gameObject.SetActive (true);

			} else {
				p1Flag.sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [2]].ToString (), typeof(Sprite)) as Sprite;
				p2Flag.sprite = Resources.Load (tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [3]].ToString (), typeof(Sprite)) as Sprite;
				GameManager.instance.p1Country = tournamentcontroller.instance.cs [0];
				GameManager.instance.p2Country = tournamentcontroller.instance.cs[tournamentcontroller.instance.r3 [3]];
				GameManager.instance.level = tournamentcontroller.instance.stars[tournamentcontroller.instance.r3 [3]];
				statusMatchTxt.text = "Third Place Playoff";

				t1.gameObject.SetActive (false);

				t2.gameObject.SetActive (false);

				t3.gameObject.SetActive (true);

				t4.gameObject.SetActive (false);
			}
			for (int i = 0; i <= 3; i++) {
				r3 [i].transform.GetChild (0).GetComponent<Image> ().sprite = Resources.Load (tournamentcontroller.instance.cs [tournamentcontroller.instance.r3 [i]].ToString (), typeof(Sprite)) as Sprite;
				for (int j = 1; j <= 3; j++) {
					r3 [i].transform.GetChild (0).transform.GetChild (0).transform.GetChild (j - 1).gameObject.SetActive (false);
				}
				for (int j = 1; j <= tournamentcontroller.instance.stars [tournamentcontroller.instance.r3 [i]]; j++) {
					r3 [i].transform.GetChild (0).transform.GetChild (0).transform.GetChild (j - 1).gameObject.SetActive (true);
				}
			}
		} else {
			for (int i = 0; i <= 3; i++) 
				r3 [i].transform.GetChild (0).gameObject.SetActive (false);
		}
		if (GameManager.instance.tournamentRound >= 4) {
			//for (int i = 0; i <= 5; i++)
				//vsPanel.transform.GetChild (i).transform.gameObject.SetActive (false);
			vsPanel.gameObject.SetActive (false);	
			statusTxt.gameObject.SetActive (true);
			if (tournamentcontroller.instance.rankFinal == 4) {
				statusTxt.text = "4 Place!";
				if (GameManager.instance.kindOfTournament == 1) {
				}
			}
			if (tournamentcontroller.instance.rankFinal == 3) {
				statusTxt.text = "3 Place!";
				if (GameManager.instance.kindOfTournament == 1) {
					PlayerPrefs.SetInt ("f3", PlayerPrefs.GetInt ("f3") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 2) {
					PlayerPrefs.SetInt ("w3", PlayerPrefs.GetInt ("w3") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 3) {
					PlayerPrefs.SetInt ("s3", PlayerPrefs.GetInt ("s3") + 1);
				} 
			}
			if (tournamentcontroller.instance.rankFinal == 2) {
				statusTxt.text = "2 Place!";
				if (GameManager.instance.kindOfTournament == 1) {
					PlayerPrefs.SetInt ("f2", PlayerPrefs.GetInt ("f2") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 2) {
					PlayerPrefs.SetInt ("w2", PlayerPrefs.GetInt ("w2") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 3) {
					PlayerPrefs.SetInt ("s2", PlayerPrefs.GetInt ("s2") + 1);
				} 
			}
			if (tournamentcontroller.instance.rankFinal == 1) {
				statusTxt.text = "1 Place!";
				if (GameManager.instance.kindOfTournament == 1) {
					PlayerPrefs.SetInt ("f1", PlayerPrefs.GetInt ("f1") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 2) {
					PlayerPrefs.SetInt ("w1", PlayerPrefs.GetInt ("w1") + 1);
				} 
				if (GameManager.instance.kindOfTournament == 3) {
					PlayerPrefs.SetInt ("s1", PlayerPrefs.GetInt ("s1") + 1);
				} 
			}
		}
		if (GameManager.instance.tournamentRound == 2 && tournamentcontroller.instance.r2 [0] != 0) {
			//for (int i = 0; i <= 5; i++)
			//	vsPanel.transform.GetChild (i).transform.gameObject.SetActive (false);
			vsPanel.gameObject.SetActive (false);	
			statusTxt.gameObject.SetActive (true);

			t1.gameObject.SetActive (true);

			t2.gameObject.SetActive (false);

			t3.gameObject.SetActive (false);

			t4.gameObject.SetActive (false);

			statusTxt.text = "Eliminated in Quater Finals";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
