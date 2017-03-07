using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

	public GameObject ghost;

	private GameObject player;
	private CharacterController characterController;

	private GameObject m_GhostSpawned;

	private Rigidbody m_Rb;

	private bool m_Grounded;
	private bool m_CanSpawn;
	private bool m_CoroutineStarted;

	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;

	// Use this for initialization
	void Start () {
		
		m_Grounded = true;
		m_CanSpawn = false;
		m_CoroutineStarted = false;

		player = GameObject.FindGameObjectWithTag ("Player");
		characterController = player.GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		if((characterController.isGrounded && m_Grounded) || (characterController.isGrounded && m_CanSpawn)) {
			m_Grounded = false;

			m_CameraPosition = player.transform.GetChild (0).transform.position;

		//	Vector3 newDirection = Vector3.RotateTowards (transform.forward, m_CameraDirection, step, 0.0f);

			Vector3 spawnLocation = m_CameraPosition + new Vector3 (0.0f, 0.0f, Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);
			Instantiate (ghost, spawnLocation, spawnRotation);

			m_CanSpawn = false;

			if (!m_CoroutineStarted) StartCoroutine(SpawnTimer());
		}



	}

	IEnumerator SpawnTimer() {
		
		m_CoroutineStarted = true;
		yield return new WaitForSeconds(2);
		m_CanSpawn = true;
		StartCoroutine(SpawnTimer());
	}
}
