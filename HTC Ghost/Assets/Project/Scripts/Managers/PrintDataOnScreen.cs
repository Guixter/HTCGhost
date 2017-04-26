using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * The HUD printer.
 */
public class PrintDataOnScreen : MonoBehaviour {

	private Transform score;
	private Vector2 anchorMinRef;
	private Vector2 anchorMaxRef;
	private List<Image> imagesOfLives;
	private bool isGameOver;
	private int initialNumberOfLives;
	private PlayerManager player;

	public Image lifePrefab;
	public Vector2 translation;
	public Sprite off;
	public GameObject gameOverCanvas, gameOverText;

	public GameObject parent;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("GameManager").GetComponent<PlayerManager> ();

		this.score = this.transform.FindChild ("Score");
		anchorMaxRef = lifePrefab.rectTransform.anchorMax;
		anchorMinRef = lifePrefab.rectTransform.anchorMin;
		initialNumberOfLives = player.life;
		this.initLives (initialNumberOfLives);
	}

	// Init the lifes
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

	// Handle the lost lifes
	public void livesLost(int totalNumberOfLivesLost){
		List<Image>.Enumerator e = this.imagesOfLives.GetEnumerator ();
		for (int curIndex = 0; curIndex < totalNumberOfLivesLost; curIndex++) {
			e.MoveNext ();
			Image curImage = e.Current;
			curImage.sprite = off;
		}

	
	}

	// Print the current life
	public void PrintCurrentLife(){
		initLives(initialNumberOfLives);
		livesLost (initialNumberOfLives - player.life);
	}

	// Print the current score
	public void PrintScore() {
		if (this.score.gameObject.activeInHierarchy) {
			this.score.GetComponent<Text> ().text = "Score : " + player.score;
		}
	}
}
