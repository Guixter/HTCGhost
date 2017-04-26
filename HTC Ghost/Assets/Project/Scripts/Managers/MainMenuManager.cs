using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * The Main Menu Manager.
 */
public class MainMenuManager : MonoBehaviour {

	// Exit the game
	public void Exit() {
		Application.Quit ();
	}

	// Play the game
	public void Play() {
		SceneManager.LoadScene ("Game");
	}

	// Go to the menu
	public void Menu() {
		SceneManager.LoadScene ("Menu");
	}
}
