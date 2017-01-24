using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

	int maxScore;
	public int curScore {
		get { return maxScore - countPickups (); }
	}
	float timeSinceWin = 0;

	public GameObject winText;

	// Use this for initialization
	void Start () {
		winText.SetActive (false);

		maxScore = countPickups ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text> ().text = curScore.ToString () + " / " + maxScore.ToString ();
		if (curScore >= 43) {
			winText.SetActive (true);
			timeSinceWin += Time.deltaTime;
			if (timeSinceWin > 5) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	int countPickups () {
		return GameObject.FindGameObjectsWithTag ("Pickup").Length;
	}

}
