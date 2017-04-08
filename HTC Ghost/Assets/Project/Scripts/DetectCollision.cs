using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pumpkin")) {
			if (GameObject.Find ("DataOnScreen") != null) {
				PrintDataOnScreen print = GameObject.Find ("DataOnScreen").GetComponent<PrintDataOnScreen> ();
				print.playerLife -= 1;
				print.PrintCurrentLife ();
				Destroy (other.gameObject);
			}
		}
	}
}
