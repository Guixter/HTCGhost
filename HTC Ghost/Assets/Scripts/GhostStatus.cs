using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStatus : MonoBehaviour {

	public int m_Health;
	public float m_Speed;

	// Use this for initialization
	void Start () {
		m_Health = 300;
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Health <= 0) {
			Destroy (this.gameObject);
		}
	}

	int GetHealth() {
		return this.m_Health;
	}

	void SetHealth(int newHealth) {
		m_Health = newHealth;

	}
}
