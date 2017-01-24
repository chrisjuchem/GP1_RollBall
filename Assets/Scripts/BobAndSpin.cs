using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAndSpin : MonoBehaviour {

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

	//Rotates the object by the rotate speed each frame around the vertical axis
	void Rotate(){
		// -90 instead of 90 to make it got CCW
		transform.Rotate (new Vector3 (0, -90, 0) * Time.deltaTime * rotateSpeed);
	}

	//Bobs the object up and down fully once every bobDuration seconds
	void Bob() {
		// Making sure to adjust for radians
		float y = height + (Mathf.Sin (Time.time * 2 * Mathf.PI / bobDuration) * bobHeight);
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}


}
