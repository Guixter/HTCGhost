using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the ghosts spawning.
 */
public class SpawnGhost : MonoBehaviour {

	public GameObject ghostRed;
	public GameObject ghostGreen;
	public GameObject player;
	public GameObject target;

	public float height;
	public float rot;
	public bool testHeight;
	public bool testRot;

	private CharacterController characterController;

	private GameObject m_GhostSpawned;

	private Rigidbody m_Rb;

	private bool m_CanSpawn;
	private bool m_CoroutineStarted;

	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;
	private int ghostRedCount = 5;
	private int ghostCount;
	private float ghostSpawnTime = Constants.GHOST_SPAWN_INIT_TIME;

	///////////////////////////////////////////////////////////////////////////////

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

			// Tests
			if (testHeight) {
				randRotationX = height;
			}
			Debug.Log ('*' + randRotationY);


			m_CameraPosition = target.transform.position;
			Vector3 spawn =  m_CameraPosition + (Quaternion.Euler(0, randRotationY, 0) * Quaternion.Euler(randRotationX, 0, 0)) * (Vector3.forward * Constants.GHOST_SPAWN_RADIUS);
			Quaternion spawnRotation = Quaternion.Euler (-90.0f, 0.0f, 0.0f);

			ghostRedCount--;
			if (ghostRedCount <= 0) {
				ghostRedCount = Constants.GHOST_GREEN_TRESHOLD;
				Instantiate (ghostGreen, spawn, spawnRotation);
			} else {
				Instantiate (ghostRed, spawn, spawnRotation);
			}
			ghostCount++;

			if (ghostCount % Constants.GHOST_WAVES_SIZE == 0)
				ghostSpawnTime = Mathf.Max(ghostSpawnTime - Constants.GHOST_SPAWN_TIME_DECR, Constants.GHOST_MIN_SPAWN_TIME);
			
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
