using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	private Text scoreLabel;
	private int score = 0;

	// Use this for initialization
	void Start () {
		scoreLabel = this.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreLabel.text = score.ToString();
	}

	public void AddPoints(int points) {
		score += points;
	}

	public void RemovePoins(int points) {
		score -= points;
	}

	public int GetScore() {
		return score;
	}

	public void ResetScore() {
		score = 0;
	}
}
