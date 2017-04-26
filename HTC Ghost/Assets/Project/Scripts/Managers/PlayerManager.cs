using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Handles the player's status.
 */
public class PlayerManager : MonoBehaviour {

	public int life;
	public int score;

	private PrintDataOnScreen print;
	private bool isGameOver;
	private int highscore;

	// Use this for initialization
	void Start() {
		isGameOver = false;
		highscore = PlayerPrefs.GetInt ("Highscore");
		StartCoroutine (FindPrinter());
	}

	// Delay to find the printer
	IEnumerator FindPrinter() {
		yield return new WaitForSeconds (0.5f);
		print = GameObject.Find ("DataOnScreen").GetComponent<PrintDataOnScreen> ();
	}

	///////////////////////////////////////////////////////////////////////////////

	// Decrement the player's life
	public void DecrementLife() {
		life--;
		print.PrintCurrentLife ();
		if (!isGameOver) CheckGameOver();
	}

	// Increment the player's score
	public void AddScore(int value) {
		score += value;
		print.PrintScore ();
	}

	// Check if the game is over
	private void CheckGameOver() {
		if (life <= 0) {
			isGameOver = true;
			PlayerPrefs.SetInt ("PlayerScore", score);

			AudioSource deathSound = GetComponent<AudioSource>();
			deathSound.Play();

			if (score > highscore) {
				PlayerPrefs.SetInt ("Highscore", score);
			}

			StartCoroutine(WaitTransition());
		}
	}

	// Wait the end of the transition
	IEnumerator WaitTransition() {
		yield return new WaitForSeconds(3.0f);
		SceneManager.LoadScene ("GameOver");
	}

}
