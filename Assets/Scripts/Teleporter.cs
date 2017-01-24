using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public Teleporter target;

	public void Teleport(Player player) {
		Vector3 dir = new Vector3 (target.transform.position.x - transform.position.x,
			0, target.transform.position.z - transform.position.z);
		dir += (player.GetComponent<Rigidbody> ().velocity.normalized * 1.3f);
		player.transform.Translate (dir, Space.World);
	}
}
