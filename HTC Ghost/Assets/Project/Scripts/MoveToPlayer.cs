using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the movement of a ghost.
 */
public class MoveToPlayer : MonoBehaviour {

	private Rigidbody m_Rb;
	private Vector3 m_CameraPosition;
	private Vector3 m_CameraDirection;
	private bool m_FirstTime;

	// Use this for initialization
	void Start () {
		m_Rb = GetComponent<Rigidbody> ();
		m_FirstTime = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!m_FirstTime) {
			m_CameraPosition = Camera.main.transform.position;

			m_CameraDirection = m_CameraPosition - transform.position;
			float step = 0.1f * Time.deltaTime;
			Vector3 newDirection = Vector3.RotateTowards (transform.forward, m_CameraDirection, step, 0.0f);

			transform.rotation = Quaternion.LookRotation (newDirection);
			m_FirstTime = true;
		}

		m_CameraPosition = Camera.main.transform.position;

		m_Rb.velocity = (m_CameraPosition - transform.position).normalized * Constants.GHOST_SPEED;  
		m_Rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
	}
}
