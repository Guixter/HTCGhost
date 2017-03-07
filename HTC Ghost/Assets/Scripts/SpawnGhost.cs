using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

	public GameObject ghost;
	public GameObject player;
	public GameObject target;

	private CharacterController characterController;

	private GameObject m_GhostSpawned;

	private Rigidbody m_Rb;

	private bool m_CanSpawn;
	private bool m_CoroutineStarted;

	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;

	// Use this for initialization
	void Start () {
		
		m_CanSpawn = true;
		m_CoroutineStarted = false;


	}
	
	// Update is called once per frame
	void Update () {

		if(m_CanSpawn) {

			float randRotationX = Random.Range (-15.0f, 45.0f);

			float randRotationY = Random.Range(0.0f, 360.0f);

			Vector3 spawn =  m_CameraPosition + Quaternion.Euler(randRotationX,randRotationY,0) * (player.transform.forward.normalized * Constants.GHOST_SPAWN_RADIUS);

			Vector3 newDirection = Vector3.RotateTowards (spawn, m_CameraDirection, 1.0f, 0.0f);

			//m_CameraPosition = player.transform.GetChild (0).position;
			m_CameraPosition = target.transform.position;

		//	Vector3 newDirection = Vector3.RotateTowards (transform.forward, m_CameraDirection, step, 0.0f);

			Vector3 spawnLocation = m_CameraPosition + new Vector3 (0.0f, 0.0f, Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);
			Instantiate (ghost, spawn, spawnRotation);

			m_CanSpawn = false;

			if (!m_CoroutineStarted) StartCoroutine(SpawnTimer());
		}



	}

	IEnumerator SpawnTimer() {
		
		m_CoroutineStarted = true;
		yield return new WaitForSeconds(5);
		m_CanSpawn = true;
		StartCoroutine(SpawnTimer());
	}
}
