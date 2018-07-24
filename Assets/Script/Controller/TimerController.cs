using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

	public Sprite buttonSprite;

	private Text timerLabel;
	private ScoreController scoreController;
	private ReadyEvent readyEvent;
	private TimeUpEvent timeupEvent;
	private GameObject highScoreButton;
	private GameObject restartButton;
	private GameObject menuButton;
	private float runtime = 3f;
	private float count;
	private bool running = true;

	// Use this for initialization
	void Start () {
		timerLabel = this.GetComponent<Text> ();
		scoreController = GameObject.Find ("score").GetComponent<ScoreController> ();
		readyEvent = GameObject.Find ("ready_event").GetComponent<ReadyEvent> ();
		timeupEvent = GameObject.Find ("time_up_event").GetComponent<TimeUpEvent> ();
		highScoreButton = GameObject.Find ("highscore_button");
		restartButton = GameObject.Find ("restart_button");
		menuButton = GameObject.Find ("menu_button");

		Restart ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (readyEvent.HasStarted ()) {
			if ((int)count == 0) {
				running = false;
				timeupEvent.ShowTimeUp ();
			}

			if ((int)count > 0) {
				count -= Time.deltaTime;
				timerLabel.text = ((int)count).ToString ();
			}
		}
	}

	void SaveHighScore() {
		int highscore = PlayerPrefs.GetInt ("HighScore");
		int score = scoreController.GetScore ();

		if (score > highscore) {
			PlayerPrefs.SetInt ("HighScore", score);
		}
	}

	void HideButtons() {
		highScoreButton.SetActive (false);
		restartButton.SetActive (false);
		menuButton.SetActive (false);
	}

	void ShowButtons() {
		highScoreButton.SetActive (true);
		restartButton.SetActive (true);
		menuButton.SetActive (true);
	}

	public bool isRunning() {
		return running;
	}

	public void Stop() {
		print ("Time stoped");
		Time.timeScale = 0;
		ShowButtons ();
		SaveHighScore ();
	}

	public void Restart() {
		HideButtons ();
		readyEvent.Restart ();
		Time.timeScale = 1;
		running = true;
		count = runtime;
	}
}
