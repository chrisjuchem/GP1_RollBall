﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed;

	void FixedUpdate () {
		Move ();

		if (transform.position.y < -100) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		}
	}

	void Move() {
		Vector3 dir = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		gameObject.GetComponent<Rigidbody> ().AddForce (dir * speed);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
		} else if (other.gameObject.CompareTag ("TP")) {
			other.gameObject.GetComponent<Teleporter>().Teleport (this);
		}
	}
}
