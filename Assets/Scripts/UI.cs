using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Script for score tacking and UI management
public class UI : MonoBehaviour {

	int maxScore;
	public int curScore {
		//dynamically calculate the score when needed
		get { return maxScore - countPickups (); }
	}

	//timer for game reset after win
	float timeSinceWin = 0;

	public GameObject winText;


	void Start () {
		winText.SetActive (false);

		//count all the pickups we could possibly get
		maxScore = countPickups ();
	}
	
	// Update is called once per frame
	void Update () {
		// Update the score counter
		gameObject.GetComponent<Text> ().text = curScore.ToString () + " / " + maxScore.ToString ();

		// Check if we've won and execute win behavior of so
		if (curScore >= maxScore) {
			winText.SetActive (true);
			timeSinceWin += Time.deltaTime;
			if (timeSinceWin > 5) {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
		}
	}

	// counts the number of active pickups in the level
	int countPickups () {
		return GameObject.FindGameObjectsWithTag ("Pickup").Length;
	}

}
