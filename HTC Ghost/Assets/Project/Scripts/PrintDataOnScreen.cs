using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrintDataOnScreen : MonoBehaviour {


	private int highscore;

	private Transform score;
	//private Canvas canvas;
	private Vector2 anchorMinRef;
	private Vector2 anchorMaxRef;
	private List<Image> imagesOfLives;


	public Image lifePrefab;
	public Vector2 translation;
	public int initialNumberOfLives;
	public Sprite off;
	public GameObject gameOverCanvas, gameOverText;

	public int playerLife;
	public int playerScore;
	public GameObject parent;

	// Use this for initialization
	void Start () {
		
		highscore = PlayerPrefs.GetInt ("Highscore");

		this.score = this.transform.FindChild ("Score");
		//this.canvas = FindObjectOfType<Canvas> ();
		Debug.Log (score);
		anchorMaxRef = lifePrefab.rectTransform.anchorMax;
		anchorMinRef = lifePrefab.rectTransform.anchorMin;
		this.initLives (initialNumberOfLives);

		playerLife = initialNumberOfLives;
		playerScore = 0;
	}

	// Update is called once per frame
	void Update () {
		//PrintScore ();

		/*if (Controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_ApplicationMenu)) {
			Time.timeScale = 0;
		}*/

	}

	private void CheckGameOver() {
		if (playerLife <= 0) {
			
			if (playerScore > highscore) {
				PlayerPrefs.SetInt ("Highscore", playerScore);
			}

			Time.timeScale = 0;
			gameOverText.GetComponent<Text> ().text = "Your score : " + playerScore + "\nBest score : " + PlayerPrefs.GetInt ("Highscore");
			gameOverCanvas.SetActive (true);
			//SceneManager.LoadScene ("Menu");
		}
	}

	private void initLives(int initialNumberOfLives){
		if (this.imagesOfLives != null) {
			foreach (Image im in this.imagesOfLives) {
				Destroy (im.gameObject);
			}
			this.imagesOfLives.Clear ();
		}
		this.imagesOfLives = new List<Image> ();
		for(int curIndex = 0; curIndex < initialNumberOfLives; curIndex++) {
			
			Image curLife = GameObject.Instantiate (lifePrefab);

			curLife.transform.SetParent (parent.transform, false);
			curLife.rectTransform.anchorMin = anchorMinRef + curIndex * translation;
			curLife.rectTransform.anchorMax = anchorMaxRef + curIndex * translation;
			this.imagesOfLives.Add (curLife);
		}
		this.imagesOfLives.Reverse ();
	}

	public void livesLost(int totalNumberOfLivesLost){

		List<Image>.Enumerator e = this.imagesOfLives.GetEnumerator ();
		for (int curIndex = 0; curIndex < totalNumberOfLivesLost; curIndex++) {
			e.MoveNext ();
			Image curImage = e.Current;
			curImage.sprite = off;
			//curImage.enabled = false;
		}

	
	}

	public void PrintCurrentLife(){
		initLives(initialNumberOfLives);
		livesLost (initialNumberOfLives - playerLife);
		CheckGameOver();
	}

	public void PrintScore() {
		if (this.score.gameObject.activeInHierarchy) {
			this.score.GetComponent<Text> ().text = "Score : " + playerScore;
		}
	}
}
