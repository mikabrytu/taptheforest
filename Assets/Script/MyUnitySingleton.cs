using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnitySingleton : MonoBehaviour {

	private static MyUnitySingleton instance = null;

	public static MyUnitySingleton Instance {
		get { return instance; }
	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			AudioSource soundtrack = GameObject.Find ("soundtrack").GetComponent<AudioSource> ();
			if (soundtrack != null && !soundtrack.isPlaying) {
				soundtrack.Play ();
			}

			instance = this;
		}

		DontDestroyOnLoad(this.gameObject);
	}
}
