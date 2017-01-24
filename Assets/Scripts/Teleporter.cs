using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Teleporter target;

	public int required;

	bool on = false;
	float offDropDist = 0.5f;

	float bobHght;

	public void Start() {
		transform.Translate (Vector3.down * offDropDist);
		bobHght = GetComponent<BobAndSpin> ().bobHeight;
		GetComponent<BobAndSpin> ().bobHeight = 0;
	}

	public void Update() {
		if (!on && GameObject.FindWithTag ("UI").GetComponent<UI> ().curScore >= required) {
			on = true;
			transform.Translate (Vector3.up * offDropDist);
			GetComponent<BobAndSpin> ().bobHeight = bobHght;
			Debug.Log ("on");
		}
	}

	public void Teleport(Player player) {
		if (on) {
			Vector3 dir = new Vector3 (target.transform.position.x - transform.position.x,
				             0, target.transform.position.z - transform.position.z);
			dir += (player.GetComponent<Rigidbody> ().velocity.normalized * 1.3f);
			player.transform.Translate (dir, Space.World);
		}
	}
}
