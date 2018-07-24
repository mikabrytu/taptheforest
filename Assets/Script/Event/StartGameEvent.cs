using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameEvent : MonoBehaviour {

	private AudioSource soundtrack;

	// Use this for initialization
	void Start () {
		soundtrack = GameObject.Find ("soundtrack").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		soundtrack.Stop ();
		SceneManager.LoadScene ("Main");
	}
}
