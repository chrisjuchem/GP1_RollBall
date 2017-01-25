using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Logic and behavior for the teleporters
public class Teleporter : MonoBehaviour {

	public Teleporter target;

	public int required;

	bool on = false;
	public float offDropDist = 0.5f;

	float bobHght;

	public void Start() {
		//initialize this script and the BobAndSpin script together, 
		//sinking the teleporter into the ground to signal that it is not active
		GetComponent<BobAndSpin> ().height -= offDropDist;
		bobHght = GetComponent<BobAndSpin> ().bobHeight;
		GetComponent<BobAndSpin> ().bobHeight = 0;
	}

	// Turn on the teleporter if the UI is recording a score higner 
	// than the required score to turn on 
	public void Update() {
		if (!on && GameObject.FindWithTag ("UI").GetComponent<UI> ().curScore >= required) {
			on = true;
			GetComponent<BobAndSpin> ().height += offDropDist;
			GetComponent<BobAndSpin> ().bobHeight = bobHght;
		}
	}

	//teleport the player to the target teleporter.
	public void Teleport(Player player) {
		if (on) {
			// the direction to move the player in (player never changes height)
			Vector3 dir = new Vector3 (target.transform.position.x - transform.position.x,
				             0, target.transform.position.z - transform.position.z);
			// Add 1.3 units so that the 1 unit wide sphere and .25 unit wide teleporter
			// are never intersecting after the teleport, sending the sphere
			// back and forth every frame forever
			dir += (player.GetComponent<Rigidbody> ().velocity.normalized * 1.3f);

			player.transform.Translate (dir, Space.World);
		}
	}
}
