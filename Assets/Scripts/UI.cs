using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	int maxScore;
	int curScore;

	// Use this for initialization
	void Start () {
		maxScore = countPickups ();
	}
	
	// Update is called once per frame
	void Update () {
		curScore = maxScore - countPickups ();
		gameObject.GetComponent<Text> ().text = curScore.ToString () + " / " + maxScore.ToString ();
	}

	int countPickups () {
		return GameObject.FindGameObjectsWithTag ("Pickup").Length;
	}

}
