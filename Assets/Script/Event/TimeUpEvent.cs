using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpEvent : MonoBehaviour {

	public GameObject timeup;

	private GameObject cloneTimeup;
	private TimerController timerController;
	private bool isTimeupOnScreen = false;
	private bool isGameStopped = false;

	// Use this for initialization
	void Start () {
		timerController = GameObject.Find ("timer").GetComponent<TimerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isTimeupOnScreen && !isGameStopped && cloneTimeup == null) {
			timerController.Stop ();
			isGameStopped = true;
			isTimeupOnScreen = false;
		}
	}

	public void ShowTimeUp() {
		if (!isTimeupOnScreen) {
			cloneTimeup = Instantiate (timeup, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
			Destroy (cloneTimeup, 2f);
			isTimeupOnScreen = true;
		}
		isGameStopped = false;
	}

	public bool IsTimeupOnScreen() {
		return isTimeupOnScreen;
	}
}
