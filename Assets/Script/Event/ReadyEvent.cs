using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyEvent : MonoBehaviour {

	public GameObject ready;
	public GameObject go;

	private bool started = false;
	private bool hasReadyShown = false;
	private bool hasGoShown = false;
	private GameObject cloneReady;
	private GameObject cloneGo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!started) {
			if (cloneReady == null && hasReadyShown) {
				hasReadyShown = false;
				ShowGo ();
			} else {
				Destroy (cloneReady, 2f);
			}

			if (cloneGo == null && hasGoShown) {
				hasGoShown = false;
				StartGame ();
			} else {
				Destroy (cloneGo, 1f);
			}
		}
	}

	void ShowReady() {
		cloneReady = Instantiate (ready, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
		hasReadyShown = true;
	}

	void ShowGo() {
		cloneGo = Instantiate (go, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1), Quaternion.identity);
		hasGoShown = true;
	}

	void StartGame() {
		started = true;
	}

	public bool HasStarted() {
		return started;
	}

	public void Restart() {
		ShowReady ();
		started = false;
	}
}
