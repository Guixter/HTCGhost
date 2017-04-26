using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handle the detection collision between a ghost and the player's head.
 */
public class HeadCollision : MonoBehaviour {

	// Called when collider enters the head
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pumpkin")) {
			GameObject.Find ("GameManager").GetComponent<PlayerManager> ().DecrementLife ();
			Destroy (other.gameObject);
		}
	}
}
