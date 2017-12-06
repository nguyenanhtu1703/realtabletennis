using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class racketcontroller : MonoBehaviour {

	// Use this for initialization

	public static racketcontroller instance = null;

	public Image[] tmp;

	public int currentR;

	public Text infoTxt, infoTxt2;

	public GameObject usingBttn, UseBttn;

	public Image GoalBar, PowerBar, SpinBar;

	public Text moneyBaseTxt, notEnoughCoinTxt;

	public int kind;

	public GameObject[] buttonRacket, ball, trail;

	public GameObject g1, g2, g3, g4, g5, g6, g7, b1, b2, b3, b4, b5, b6;

	public string[] rn, bn, tn;

	public Text nThg;

	public string[] StringColors = { "#fff182", "#7b7c7b", "#fc8904", "#f6595c", "#4fe765", "#a648e7", 
		"#fda3ed", "#126eec", "#3dbffc", "#a2f4ed", "#85d74e", "#fd4498", "#a17374", "#8adcba", "#464d58", "#000bfc", "#feca3d", 
		"#fd4040", "#6201fc", "#fd0394", "#FF00F7", "#FF0000", "#FFFF00" }; 

	public Image statusImg, statusImag2;

	public GameObject buyBall, ownAlready;

	public void Check(){
		if (kind == 1) {
			if (currentR < 5 || PlayerPrefs.GetInt ("b" + currentR.ToString ()) == 1 || PlayerPrefs.GetInt("BUYALL") == 1) {
				UseBttn.gameObject.SetActive (true);
				buyBall.gameObject.SetActive (false);
			} else {
				UseBttn.gameObject.SetActive (false);
				buyBall.gameObject.SetActive (true);
				if (currentR == 2)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 50,000";
				else if (currentR == 3)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 5,000,000";
				else if (currentR == 4)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 500,000,000";
				else buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 50,000";
			}
		} else {
			if (currentR < 5 || PlayerPrefs.GetInt ("t" + currentR.ToString ()) == 1 || PlayerPrefs.GetInt("BUYALL") == 1) {
				UseBttn.gameObject.SetActive (true);
				buyBall.gameObject.SetActive (false);
			} else {
				UseBttn.gameObject.SetActive (false);
				buyBall.gameObject.SetActive (true);
				if (currentR == 2)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 70,000";
				else if (currentR == 3)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 7,000,000";
				else if (currentR == 4)
					buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 700,000,000";
				else buyBall.transform.GetChild (0).GetComponent<Text> ().text = "Buy 700,000,000,000";
			}
		}
	}

	public void UpKind(){
		int a = 1;
		foreach (GameObject tmp in buttonRacket) {
			if (kind == 0) {
				tmp.gameObject.SetActive (true);
				buyBall.gameObject.SetActive (false);
				//ownAlready.gameObject.SetActive (false);
				tmp.GetComponent<Image> ().sprite = Resources.Load ("r" + a.ToString (), typeof(Sprite)) as Sprite;
				tmp.GetComponent<Image> ().color = Color.white;
			} else if (kind == 1) {
				buyBall.gameObject.SetActive (true);
				//ownAlready.gameObject.SetActive (true);
				tmp.GetComponent<Image> ().sprite = Resources.Load ("b" + a.ToString(), typeof(Sprite)) as Sprite;
				Color c = new Color ();
				ColorUtility.TryParseHtmlString (StringColors [a - 1], out c);
			//	tmp.GetComponent<Image> ().color = c;
				if (a >= 7) {
					tmp.gameObject.SetActive (false);
					continue;
				}
			//	statusImg.sprite = Resources.Load ("ball", typeof(Sprite)) as Sprite;
			   //statusImg.color = c;
			} else {
				buyBall.gameObject.SetActive (true);
				//ownAlready.gameObject.SetActive (true);
				tmp.GetComponent<Image> ().sprite = Resources.Load ("t" + a.ToString(), typeof(Sprite)) as Sprite;
				Color c = new Color ();
				ColorUtility.TryParseHtmlString (StringColors [a - 1], out c);
			//	tmp.GetComponent<Image> ().color = c;
				if (a >= 7) {
					tmp.gameObject.SetActive (false);
					continue;
				}				
			//	statusImg.sprite = Resources.Load ("trail", typeof(Sprite)) as Sprite;
			//	//statusImg.color = c;
			}
			a++;
		}
		if (kind == 0) {
			statusImag2.gameObject.SetActive (false);
			statusImg.gameObject.SetActive (true);
			infoTxt.gameObject.SetActive (true);
			infoTxt2.gameObject.SetActive (false);
			b1.gameObject.SetActive (true);
			b2.gameObject.SetActive (false);
			b3.gameObject.SetActive (false);
			b4.gameObject.SetActive (false);
			b5.gameObject.SetActive (true);
			b6.gameObject.SetActive (true);
			g1.gameObject.SetActive (true);
			g2.gameObject.SetActive (true);
			g3.gameObject.SetActive (true);
			g4.gameObject.SetActive (true);
			g5.gameObject.SetActive (true);
			g6.gameObject.SetActive (true);
			g7.gameObject.SetActive (true);
			foreach(GameObject tmp in ball) tmp.gameObject.SetActive(true);
			for(int i = 0; i < trail.Length; i++){
				trail[i].gameObject.SetActive (true);
				if(i < GameManager.instance.profileLevel || PlayerPrefs.GetInt("BUYALL") == 1)
					trail[i].gameObject.SetActive (false);
			}
		} else {
			if (kind == 1) {
				statusImag2.gameObject.SetActive (true);
				statusImg.gameObject.SetActive (false);
				infoTxt.gameObject.SetActive (false);
				infoTxt2.gameObject.SetActive (true);

				b1.gameObject.SetActive (false);
				b2.gameObject.SetActive (true);
				b3.gameObject.SetActive (false);
				b4.gameObject.SetActive (true);
				b5.gameObject.SetActive (false);
				b6.gameObject.SetActive (true);
				for(int i = 0; i < trail.Length; i++){
					trail[i].gameObject.SetActive (true);
					if(i < 5 || i >= 6 || (PlayerPrefs.GetInt("b" + i.ToString()) == 1) || PlayerPrefs.GetInt("BUYALL") == 1)
						trail[i].gameObject.SetActive (false);
				}
			} else {
				statusImag2.gameObject.SetActive (true);
				statusImg.gameObject.SetActive (false);
				infoTxt.gameObject.SetActive (false);
				infoTxt2.gameObject.SetActive (true);

				b1.gameObject.SetActive (false);
				b2.gameObject.SetActive (false);
				b3.gameObject.SetActive (true);
				b4.gameObject.SetActive (true);
				b5.gameObject.SetActive (true);
				b6.gameObject.SetActive (false);
				for(int i = 0; i < trail.Length; i++){
					trail[i].gameObject.SetActive (true);
					if(i < 5 || i >= 6 || (PlayerPrefs.GetInt("t" + i.ToString()) == 1) || PlayerPrefs.GetInt("BUYALL") == 1)
						trail[i].gameObject.SetActive (false);
				}
			}
			g1.gameObject.SetActive (false);
			g2.gameObject.SetActive (false);
			g3.gameObject.SetActive (false);
			g4.gameObject.SetActive (false);
			g5.gameObject.SetActive (false);
			g7.gameObject.SetActive (false);
			g6.gameObject.SetActive (false);
			foreach(GameObject tmp in ball) tmp.gameObject.SetActive(false);
		}
	}

	public void UpLock(){
		if (kind == 0) {
			for (int i = 0; i < trail.Length; i++) {
				trail [i].gameObject.SetActive (true);
				if (i < GameManager.instance.profileLevel || PlayerPrefs.GetInt ("BUYALL") == 1)
					trail [i].gameObject.SetActive (false);
			}
		} else if (kind == 1) {
			for (int i = 0; i < trail.Length; i++) {
				trail [i].gameObject.SetActive (true);
				if (i < 5 || i >= 6 || (PlayerPrefs.GetInt ("b" + i.ToString ()) == 1) || PlayerPrefs.GetInt ("BUYALL") == 1)
					trail [i].gameObject.SetActive (false);
			}
		} else {
			for(int i = 0; i < trail.Length; i++){
				trail[i].gameObject.SetActive (true);
				if(i < 5 || i >= 6 || (PlayerPrefs.GetInt("t" + i.ToString()) == 1) || PlayerPrefs.GetInt("BUYALL") == 1)
					trail[i].gameObject.SetActive (false);
			}
		}
	}

	void Start () {
		kind = 0;
		UpKind ();
		if (instance == null)
			instance = this;
		else {
			Destroy (this.gameObject);
			return;
		}
		//DontDestroyOnLoad (this.gameObject);
		if (kind == 0)
			currentR = PlayerPrefs.GetInt ("racket");
		else if (kind == 1)
			currentR = PlayerPrefs.GetInt ("ball");
		else
			currentR = PlayerPrefs.GetInt ("trail");
		UpCurrentRacket (currentR);
		mainmenucontroller.instance.LevelUpdate ();
	}

	public void Up(){
		currentR = PlayerPrefs.GetInt ("racket");
		//UpCurrentRacket (currentR);
		ChangeRacket (currentR);
	}

	public void ChooseType(int t){
		kind = t;
		UpKind ();
		if (kind == 0)
			currentR = PlayerPrefs.GetInt ("racket");
		else if (kind == 1)
			currentR = PlayerPrefs.GetInt ("ball");
		else
			currentR = PlayerPrefs.GetInt ("trail");
		ChangeRacket (currentR);
		//UpCurrentRacket (currentR);
	}

	public bool Check(int tmp, int n){
		return (n >= tmp * 2); 
	}

	public void Change(int t){
		kind = t;
	}

	IEnumerator Run(int kkk){

		float a = (currentR + 1) / 12f, b = (kkk + 1) / 12f;

		float z = (b - a) / 10;

		if (a < b)
			for (; ; a += z) {
				if (a >= b)
					a = b;
				GoalBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a >= b)
					break;
			}
		else {
			for (; ; a += z) {
				if (a <= b)
					a = b;
				GoalBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a <= b)
					break;
			}
		}
	}

	float Amount(int k){
		if(k == 0) 
			return 5f;
		if(k == 1) 
			return 20f;
		if(k == 2) 
			return 28;
		if(k == 3) 
			return 30;
		if(k == 4)
			return 43;
		if(k == 5) 
			return 47;
		if(k == 6) 
			return 60;
		if(k == 7) 
			return 65;
		if(k == 8) 
			return 79;
		if(k == 9) 
			return 80;
		if(k == 10) 
			return 93;
		else return 100;
	}

	float Amount2(int k){
		if(k == 0) 
			return 7f;
		if(k == 1) 
			return 23f;
		if(k == 2) 
			return 25;
		if(k == 3) 
			return 33;
		if(k == 4)
			return 40;
		if(k == 5) 
			return 45;
		if(k == 6) 
			return 55;
		if(k == 7) 
			return 60;
		if(k == 8) 
			return 73;
		if(k == 9) 
			return 85;
		if(k == 10) 
			return 96;
		else return 100;
	}

	IEnumerator RunPower(int kkk){

		float a = Amount(currentR) / 100f, b = Amount(kkk) / 100f;

		float z = (b - a) / 10;

		if (a < b)
			for (; ; a += z) {
				if (a >= b)
					a = b;
				PowerBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a >= b)
					break;
			}
		else {
			for (; ; a += z) {
				if (a <= b)
					a = b;
				PowerBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a <= b)
					break;
			}
		}

	}

	IEnumerator RunSpin(int kkk){

		float a = Amount2(currentR) / 100f, b = Amount2(kkk) / 100f;

		float z = (b - a) / 10;

		if (a < b)
			for (; ; a += z) {
				if (a >= b)
					a = b;
				SpinBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a >= b)
					break;
			}
		else {
			for (; ; a += z) {
				if (a <= b)
					a = b;
				SpinBar.transform.localScale = new Vector3 (a, 1, 1);	
				yield return new WaitForSeconds (0.01f);
				if (a <= b)
					break;
			}
		}
	}

	public void UnlockAll(){
	}

	public void BuyBall(){
		if (kind == 1) {
			if (GameManager.instance.coins < 50000) {
				StartCoroutine (NotEnough ());
				AudioManager.instance.PLAYNEG ();
			} else {
				PlayerPrefs.SetInt ("b5", 1);
				GameManager.instance.coins -= 50000;
				AudioManager.instance.Use ();
				mainmenucontroller.instance.UpdateCoin ();
				ChangeRacket (currentR);
				UpLock ();
			}
		} else {
			if (GameManager.instance.coins < 700000000000) {
				StartCoroutine (NotEnough ());
				AudioManager.instance.PLAYNEG ();
			} else {
				PlayerPrefs.SetInt ("t5", 1);
				GameManager.instance.coins -= 700000000000;
				AudioManager.instance.Use ();
				mainmenucontroller.instance.UpdateCoin ();
				ChangeRacket (currentR);
				UpLock ();
			}
		}
	}

	IEnumerator NotEnough(){
		notEnoughCoinTxt.gameObject.SetActive (true);
		notEnoughCoinTxt.GetComponent<TweenSequence> ().BeginSequence ();
		yield return new WaitForSeconds (2);
		notEnoughCoinTxt.CrossFadeAlpha (0, 1, true);
		notEnoughCoinTxt.gameObject.SetActive (false);
	}

	public void ChangeRacket(int tmp){

		if (kind == 0) {

			statusImg.sprite = Resources.Load ("r" + (tmp + 1).ToString (), typeof(Sprite)) as Sprite;

			statusImg.color = Color.white;

			StartCoroutine (RunPower (tmp));

			StartCoroutine (Run (tmp));

			StartCoroutine (RunSpin(tmp));

			if (tmp == PlayerPrefs.GetInt ("racket")) {
				usingBttn.gameObject.SetActive (true);
				UseBttn.gameObject.SetActive (false);
			} else {
				usingBttn.gameObject.SetActive (false);
				UseBttn.gameObject.SetActive (true);
			}


			moneyBaseTxt.text = "base + " + GameManager.instance.format (GameManager.instance.Bonus (tmp)) + " COINS: WIN MATCH";

			currentR = tmp;

			nThg.text = rn [currentR];

			infoTxt.gameObject.SetActive (true);
			if (currentR == PlayerPrefs.GetInt ("racket")) {
				infoTxt.text = "You are using this racket";
			} else {
				if (GameManager.instance.profileLevel - 1 < (tmp) * 1) {
					infoTxt.text = "Level " + ((tmp) * 1 + 1).ToString () + " to unlock this racket";
				} else
					infoTxt.gameObject.SetActive (false);
			}
			UpCurrentRacket (tmp);
			statusImag2.sprite = statusImg.sprite;
			infoTxt2.text = infoTxt.text;
		} else if (kind == 1) {
			
			Color c = new Color ();
			ColorUtility.TryParseHtmlString (StringColors [tmp], out c);
			statusImg.sprite = Resources.Load ("b" + (tmp + 1).ToString (), typeof(Sprite)) as Sprite;
			statusImg.color = Color.white;

			currentR = tmp;

			Check ();

			if (tmp == PlayerPrefs.GetInt ("ball")) {
				usingBttn.gameObject.SetActive (true);
				UseBttn.gameObject.SetActive (false);
			} else {
				usingBttn.gameObject.SetActive (false);
				UseBttn.gameObject.SetActive (true);
			}

		//	infoTxt.gameObject.SetActive (true);
			if (currentR == PlayerPrefs.GetInt ("ball")) {
				infoTxt.text = "You are using this ball";
			} else {
				if (currentR >= 2 && PlayerPrefs.GetInt("b" + currentR.ToString()) == 0) {
					infoTxt.text = "You need to buy this ball";
				} else
					infoTxt.gameObject.SetActive (false);
			}
			UpCurrentRacket (tmp);

			nThg.text = bn [currentR];

			statusImag2.sprite = statusImg.sprite;
			infoTxt2.text = infoTxt.text;
		} else {
			Color c = new Color ();
			ColorUtility.TryParseHtmlString (StringColors [tmp], out c);
			statusImg.sprite = Resources.Load ("t" + (tmp + 1).ToString (), typeof(Sprite)) as Sprite;
			statusImg.color = Color.white;

			currentR = tmp;

			Check ();

			if (tmp == PlayerPrefs.GetInt ("trail")) {
				usingBttn.gameObject.SetActive (true);
				UseBttn.gameObject.SetActive (false);
			} else {
				usingBttn.gameObject.SetActive (false);
				UseBttn.gameObject.SetActive (true);
			}

			//infoTxt.gameObject.SetActive (true);
			if (currentR == PlayerPrefs.GetInt ("trail")) {
				infoTxt.text = "You are using this trail";
			} else {
				if (currentR >= 2 && PlayerPrefs.GetInt("t" + currentR.ToString()) == 0) {
					infoTxt.text = "You need to buy this trail";
				} else
					infoTxt.gameObject.SetActive (false);
			}
			UpCurrentRacket (tmp);

			nThg.text = tn [currentR];

			statusImag2.sprite = statusImg.sprite;
			infoTxt2.text = infoTxt.text;
		}
		//if (GameObject.Find ("myRacket") != null) GameObject.Find ("myRacket").GetComponent<Renderer>().material.mainTexture = Resources.Load ("Bat_" + PlayerPrefs.GetInt("racket").ToString(), typeof (Texture)) as Texture;;
	}

	public bool Condition(){
		if (kind == 0) {
			if (PlayerPrefs.GetInt ("BUYALL") == 1 || GameManager.instance.profileLevel - 1 >= currentR) {
				return false;
			} else
				return true;
		} else
			return false;
		return GameManager.instance.profileLevel < currentR * 1;
	}

	public void UsePressed(){
		if (Condition () == false) {
			AudioManager.instance.Use ();
			if (kind == 0) PlayerPrefs.SetInt ("racket", currentR);
			else if(kind == 1) PlayerPrefs.SetInt ("ball", currentR);
			else PlayerPrefs.SetInt ("trail", currentR);

			ChangeRacket (currentR);
		} else {
			AudioManager.instance.PLAYNEG ();
			infoTxt.GetComponent<TweenSequence> ().BeginSequence ();
		}
	}

	public void UpCurrentRacket(int tmpp){
		for (int i = 0; i < tmp.Length; i++)
			if (i == tmpp)
				tmp [i].gameObject.SetActive (true);
			else
				tmp [i].gameObject.SetActive (false);
	}

	void Update () {
		
	}
}
