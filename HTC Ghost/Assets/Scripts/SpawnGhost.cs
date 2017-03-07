using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

	public GameObject ghost;
	public GameObject player;

	private GameObject ghostSpawned;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {

		if (player) {
			float cameraHeight = player.transform.position.y + player.transform.GetChild (0).transform.position.y;

			Vector3 spawnLocation = player.transform.position + new Vector3 (5.0f, cameraHeight, Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);
			ghostSpawned = Instantiate (ghost, spawnLocation, spawnRotation);

			rb = ghostSpawned.GetComponent<Rigidbody> ();

			Vector3 playerDirection = player.transform.position - ghostSpawned.transform.position;
			float step = 0.1f * Time.deltaTime;
			Vector3 newDirection = Vector3.RotateTowards (ghostSpawned.transform.forward, playerDirection, step, 0.0f);
			//Debug.DrawRay(ghostSpawned.transform.position, newDirection, Color.red);
			ghostSpawned.transform.rotation = Quaternion.LookRotation (newDirection);

		}
		//StartCoroutine(RotateGhost());
	}

	IEnumerator RotateGhost() {

		yield return new WaitForSeconds(0);
		print ("ROTATION");
		//ghostt.transform.rotation = Quaternion.Euler (45.0f, 90.0f, 26.0f);


	}
	
	// Update is called once per frame
	void Update () {
		if (ghostSpawned) {
			

			rb.velocity = (player.transform.position - ghostSpawned.transform.position).normalized;  


			rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY| RigidbodyConstraints.FreezeRotationZ;
		
		}
	}
}
