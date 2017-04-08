using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintDataOnScreen : MonoBehaviour {


	private int livesLeftOnScreen = 0;
	private int scoreOnScreen = 0;

	private Transform score;

	private Canvas canvas;

	private Vector2 anchorMinRef;
	private Vector2 anchorMaxRef;
	private List<Image> imagesOfLives;


	public Image lifePrefab;
	public Vector2 translation;
	public int initialNumberOfLives;
	public Sprite off;


	// Use this for initialization
	void Start () {
		this.score = this.transform.FindChild ("Score");
		this.canvas = FindObjectOfType<Canvas> ();
		Debug.Log (score);
		anchorMaxRef = lifePrefab.rectTransform.anchorMax;
		anchorMinRef = lifePrefab.rectTransform.anchorMin;
		this.initLives (initialNumberOfLives);
	}

	// Update is called once per frame
	void Update () {
		setScoreOnScreen (scoreOnScreen + 1);
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

			curLife.transform.SetParent (this.canvas.transform, false);
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

	public void currentLife(int lifeMax, int curLife){
		initLives(lifeMax);
		livesLost (lifeMax - curLife);
	}

	public void setScoreOnScreen(int newScore){
		this.scoreOnScreen = newScore;
		this.score.GetComponent<Text> ().text = "Score : " + newScore;
	}
}
