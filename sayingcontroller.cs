using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sayingcontroller : MonoBehaviour {

	// Use this for initialization

	public static sayingcontroller instance = null;
	public Image bg1, bg2;
	public Text conve1, conver2;
	string wTS;
	public GameObject cv1, cv2;
	public Transform cubeT;
	Vector3 cubeP, tmp1;
	Quaternion tmp2;
	public GameObject girl, boy;
	public bool did, did2;

	void Start () {
		//GameObject.Find ("Canvas").transform.GetChild (2).gameObject.SetActive (false);
		//girl.gameObject.SetActive (false);
	//	boy.gameObject.SetActive (false);
		if (GameManager.instance.training == false)
			return;
		//GameObject.Find ("Canvas").transform.GetChild (0).gameObject.SetActive (false);
	//	GameObject.Find ("Canvas").transform.GetChild (1).gameObject.SetActive (false);
	//	GameObject.Find ("Canvas").transform.GetChild (2).gameObject.SetActive (true);
	//	if (PlayerPrefs.GetInt ("coach") == 0) {
			//girl.gameObject.SetActive (true);
	//	} else
			//boy.gameObject.SetActive (true);
	//	GameObject.Find ("TheOne").GetComponent<Animator>().Play("stand");
		instance = this;
		//cubeP = cubeT.position;
	}

	public void Change(int z){
		if (PlayerPrefs.GetInt ("coach") == z)
			return;
		PlayerPrefs.SetInt ("coach", z);
		GameObject.Find ("Fade").GetComponent<Fading> ().Fade ();
		StartCoroutine (ChangeCo());
	}

	IEnumerator ChangeCo(){
		yield return new WaitForSeconds (0.8f);
		girl.gameObject.SetActive (false);
		boy.gameObject.SetActive (false);
		if (PlayerPrefs.GetInt ("coach") == 0) {
			girl.gameObject.SetActive (true);
		} else
			boy.gameObject.SetActive (true);
		GameObject.Find ("TheOne").GetComponent<Animator>().Play("stand");
	}

	public void Training(){
		wTS = "WTF!!!!!...";
		StartCoroutine (RunTextCo(1));
	}

	public void SetB(){
		if (PlayerPrefs.GetInt ("coach") == 0)
			bg1.gameObject.SetActive (true);
		else bg2.gameObject.SetActive (true);
	}

	IEnumerator RunTextCo(int t) {
		cv1.gameObject.SetActive (false);
		cv2.gameObject.SetActive (true);
		yield return new WaitForSeconds (2.5f);
		if (PlayerPrefs.GetInt ("coach") == 0)
			if (did == false) bg1.gameObject.SetActive (true);
		else {
			if (did == false) bg2.gameObject.SetActive (true);
			tmp1 = bg2.transform.position;
			tmp2 = bg2.transform.rotation;
			bg2.transform.position = bg2.transform.parent.GetChild (1).transform.position;
			bg2.transform.rotation = bg2.transform.parent.GetChild (1).transform.rotation;
		}
		Text ourTxt;
		if(t == 1) ourTxt = conve1;
		ourTxt = conver2;
		if (PlayerPrefs.GetInt ("coach") == 0)
			ourTxt = conve1;
		else
			ourTxt = conver2;
		for (int i = 0; i <= wTS.Length - 1; i++) {
			if (i % 14 == 0) {
				if (i != 0)
					yield return new WaitForSeconds (0.3f);
				ourTxt.text = "";
			}
			Debug.Log (ourTxt.text);
			ourTxt.text += wTS [i].ToString ();
			yield return new WaitForSeconds (0.06f);
		}
	}

	IEnumerator ContinueCo(){
		bg1.gameObject.SetActive (false);
		bg2.gameObject.SetActive (false);
		if (did == true) {
			if (did2 == true)
				yield break;
			did2 = true;
			yield return new WaitForSeconds (0.8f);
			GameObject.Find ("Fade").GetComponent<Fading> ().Fade ();
			yield return new WaitForSeconds (0.8f);
			GameObject.Find ("MainCamera").GetComponent<SmoothCamera>().TurnBack();
			SceneControllerOffline.instance.stop2 = false;
		//	GameObject.Find ("Cube").transform.position = cubeP;
			GameObject.Find ("TheOne").GetComponent<Animator>().Play("stand");
			cv1.gameObject.SetActive (true);
			cv2.gameObject.SetActive (false);
			did = false;
			did2 = false;
			yield break;
		}
		did = true;
		GameObject.Find ("Fade").GetComponent<Fading> ().Fade ();
		yield return new WaitForSeconds (0.8f);
		GameObject.Find ("TheOne").GetComponent<Animator>().Play("standup");
		if (PlayerPrefs.GetInt ("coach") == 0)
			bg1.gameObject.SetActive (false);
		else {
			bg2.gameObject.SetActive (false);
			tmp1 = bg2.transform.position;
			tmp2 = bg2.transform.rotation;
			bg2.transform.position = tmp1;
			bg2.transform.rotation = tmp2;
		}
		GameObject.Find ("MainCamera").GetComponent<SmoothCamera>().MoveToTraining2();
		if (PlayerPrefs.GetInt ("coach") == 0) yield return new WaitForSeconds (4);
		else yield return new WaitForSeconds (6);
		Debug.Log (GameObject.Find ("TheOne").GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name);
		if (GameObject.Find ("TheOne").GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "stand")
			yield break;
		GameObject.Find ("Fade").GetComponent<Fading> ().Fade ();
		yield return new WaitForSeconds (0.8f);
		GameObject.Find ("TheOne").GetComponent<Animator>().Play("stand");
		cv1.gameObject.SetActive (true);
		cv2.gameObject.SetActive (false);
		GameObject.Find ("MainCamera").GetComponent<SmoothCamera>().TurnBack();
		SceneControllerOffline.instance.stop2 = false;
		//GameObject.Find ("Cube").transform.position = cubeP;
		did = false;
		did2 = false;
	}

	public void ContinueInTraining(){
		StartCoroutine (ContinueCo());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
