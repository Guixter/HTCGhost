using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGhost : MonoBehaviour {

	public GameObject ghostRed;
	public GameObject ghostGreen;
	public GameObject player;
	public GameObject target;

	private CharacterController characterController;

	private GameObject m_GhostSpawned;

	private Rigidbody m_Rb;

	private bool m_CanSpawn;
	private bool m_CoroutineStarted;

	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;
	private int ghostRedCount = 5;
	private int ghostCount;
	private float ghostSpawnTime = Constants.GHOST_SPAWN_TIME;


	// Use this for initialization
	void Start () {
		
		m_CanSpawn = true;
		m_CoroutineStarted = false;


	}
	
	// Update is called once per frame
	void Update () {

		if(m_CanSpawn) {

			float randRotationX = Random.Range (Constants.GHOST_SPAWN_ANGLE_MIN, Constants.GHOST_SPAWN_ANGLE_MAX);

			float randRotationY = Random.Range(0.0f, 360.0f);


			//Vector3 newDirection = Vector3.RotateTowards (spawn, m_CameraDirection, 1.0f, 0.0f);

			//m_CameraPosition = player.transform.GetChild (0).position;
			m_CameraPosition = target.transform.position;

			//	Vector3 newDirection = Vector3.RotateTowards (transform.forward, m_CameraDirection, step, 0.0f);

			//Vector3 spawnLocation = m_CameraPosition + new Vector3 (0.0f, 0.0f, Constants.GHOST_SPAWN_RADIUS);

			Vector3 spawn =  m_CameraPosition + (Quaternion.Euler(0, randRotationY, 0) * Quaternion.Euler(randRotationX, 0, 0)) * (Vector3.forward * Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);

			ghostRedCount--;
			if (ghostRedCount <= 0) {
				ghostRedCount = 5;
				Instantiate (ghostGreen, spawn, spawnRotation);
			}
			else {
				Instantiate (ghostRed, spawn, spawnRotation);
			}
			ghostCount++;

			if (ghostCount % 5 == 0)
				ghostSpawnTime = ghostSpawnTime - 1.0f;
			
			m_CanSpawn = false;

			if (!m_CoroutineStarted) StartCoroutine(SpawnTimer());
		}

	 

	}

	IEnumerator SpawnTimer() {
		
		m_CoroutineStarted = true;
		yield return new WaitForSeconds(ghostSpawnTime);
		m_CanSpawn = true;
		StartCoroutine(SpawnTimer());
	}
}
