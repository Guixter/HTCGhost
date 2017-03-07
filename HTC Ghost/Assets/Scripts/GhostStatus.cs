using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStatus : MonoBehaviour {

	private int m_Health;
	private float m_Speed;

	// Use this for initialization
	void Start () {
		m_Health = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	int GetHealth() {
		return this.m_Health;
	}

	void SetHealth(int newHealth) {
		m_Health = newHealth;
	}
}
