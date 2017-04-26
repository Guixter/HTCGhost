using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * The Score Manager.
 */
public class ScoreManagement : MonoBehaviour {

	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		int playerScore = PlayerPrefs.GetInt ("PlayerScore");
		int highscore = PlayerPrefs.GetInt ("Highscore");

		gameOverText.GetComponent<Text> ().text = "Your score : " + playerScore + "\nBest score : " + highscore;
	}
}
