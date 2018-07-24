using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreValueController : MonoBehaviour {

	private Text score;

	// Use this for initialization
	void Start () {
		score = gameObject.GetComponent<Text> ();
		score.text = PlayerPrefs.GetInt ("HighScore").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
