using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour {

	public GameObject gameOverText;
	private int playerScore;
	private int highscore;

	// Use this for initialization
	void Start () {
		
		int playerScore = PlayerPrefs.GetInt ("PlayerScore");
		int highscore = PlayerPrefs.GetInt ("Highscore");

		gameOverText.GetComponent<Text> ().text = "Your score : " + playerScore + "\nBest score : " + PlayerPrefs.GetInt ("Highscore");

	}

	// Update is called once per frame
	void Update () {
		
	}
}
