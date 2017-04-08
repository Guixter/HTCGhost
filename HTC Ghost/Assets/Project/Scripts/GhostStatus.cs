using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStatus : MonoBehaviour {

	public int m_Health;
	public float m_Speed;
	public int score;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (m_Health <= 0) {
			if (GameObject.Find ("DataOnScreen") != null) {
				PrintDataOnScreen print = GameObject.Find ("DataOnScreen").GetComponent<PrintDataOnScreen> ();
				print.playerScore += this.score;
				print.PrintScore ();
				Destroy (this.gameObject);
			}
		}
	}

	int GetHealth() {
		return this.m_Health;
	}

	void SetHealth(int newHealth) {
		m_Health = newHealth;

	}
}
