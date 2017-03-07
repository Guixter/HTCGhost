using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

	public GameObject ghost;
	public GameObject player;

	private GameObject m_GhostSpawned;
	private Rigidbody m_Rb;
	private CharacterController characterController;
	private bool m_Grounded;
	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;

	// Use this for initialization
	void Start () {
		m_Grounded = false;
		characterController = player.GetComponent<CharacterController> ();

		//StartCoroutine(RotateGhost());
	}

	IEnumerator RotateGhost() {

		yield return new WaitForSeconds(0);
		print ("ROTATION");
	}
	
	// Update is called once per frame
	void Update () {

		if(characterController.isGrounded && !m_Grounded) {
			m_Grounded = true;

			m_CameraPosition = player.transform.GetChild (0).transform.position;

			Vector3 spawnLocation = m_CameraPosition + new Vector3 (0.0f, 0.0f, Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);
			m_GhostSpawned = Instantiate (ghost, spawnLocation, spawnRotation);

			m_CameraDirection = m_CameraPosition - m_GhostSpawned.transform.position;
			float step = 0.1f * Time.deltaTime;
			Vector3 newDirection = Vector3.RotateTowards (m_GhostSpawned.transform.forward, m_CameraDirection, step, 0.0f);

			m_GhostSpawned.transform.rotation = Quaternion.LookRotation (newDirection);

		}

		if (m_GhostSpawned) {

			m_Rb = m_GhostSpawned.GetComponent<Rigidbody> ();

			m_CameraPosition = player.transform.GetChild (0).transform.position;

			m_Rb.velocity = (m_CameraPosition - m_GhostSpawned.transform.position).normalized;  
			m_Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

		}
	}
}
