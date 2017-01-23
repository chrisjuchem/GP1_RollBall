using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public float bobHeight;
	public float bobDuration;

	public float rotateSpeed = 1;

	private float height;

	void Start () {
		height = transform.position.y;
	}

	void Update () {
		Rotate ();
		Bob ();
	}

	//Rotates the pickup by the rotate speed each frame around the vertical axis
	void Rotate(){
		transform.Rotate (new Vector3 (0, -90, 0) * Time.deltaTime * rotateSpeed);
	}

	//Bobs the pickup up and down fully once every bobDuration seconds
	void Bob() {
		float y = height + (Mathf.Sin (Time.time * 2 * Mathf.PI / bobDuration) * bobHeight);
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}


}
