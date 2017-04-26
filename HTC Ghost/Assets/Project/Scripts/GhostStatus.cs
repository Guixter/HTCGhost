using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the status of a pumpkin.
 */
public class GhostStatus : MonoBehaviour {

	public int health;
	public int score;

	public bool spotted;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		spotted = false;
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			GameObject.Find ("GameManager").GetComponent<PlayerManager>().AddScore(this.score);
			Destroy (this.gameObject);
		}
	}
}
