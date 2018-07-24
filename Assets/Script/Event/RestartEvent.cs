using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartEvent : MonoBehaviour {

	private ScoreController scoreController;
	private TimerController timerController;

	// Use this for initialization
	void Start () {
		scoreController = GameObject.Find ("score").GetComponent<ScoreController> ();
		timerController = GameObject.Find ("timer").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {
		scoreController.ResetScore ();
		timerController.Restart ();
	}
}
