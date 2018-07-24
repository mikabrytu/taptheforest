using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;
	public Sprite sprite6;
	public Sprite sprite7;
	public Sprite sprite8;
	public Sprite sprite9;
	public Sprite sprite10;
	public AudioSource click;
	public GameObject clickAnimation;

	private Sprite target;
	private ScoreController scoreController;
	private TimerController timerController;
	private ReadyEvent readyEvent;
	private ArrayList sprites;
	private float timer;
	private bool clicked = false;

	// Use this for initialization
	void Start () {
		sprites = new ArrayList ();
		sprites.Add (sprite1);
		sprites.Add (sprite2);
		sprites.Add (sprite3);
		sprites.Add (sprite4);
		sprites.Add (sprite5);
		sprites.Add (sprite6);
		sprites.Add (sprite7);
		sprites.Add (sprite8);
		sprites.Add (sprite9);
		sprites.Add (sprite10);

		scoreController = GameObject.Find ("score").GetComponent<ScoreController> ();
		timerController = GameObject.Find ("timer").GetComponent<TimerController> ();
		readyEvent = GameObject.Find ("ready_event").GetComponent<ReadyEvent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (readyEvent.HasStarted ()) {
			timer -= Time.deltaTime;
			target = GameObject.Find ("target").GetComponent<SpriteRenderer> ().sprite;

			if (timer <= 0 && timerController.isRunning()) {
				clicked = false;

				UpdateTimer ();
				changeSprite ();
			}
		}
	}

	void OnMouseDown() {
		if (readyEvent.HasStarted () && timerController.isRunning ()) {
			if (click != null) {
				click.Play ();
			}

			StartClickAnimation ();

			if (clicked) {
				scoreController.RemovePoins (5);
			} else {
				clicked = true;

				if (this.GetComponent<SpriteRenderer> ().sprite == target) {
					scoreController.AddPoints (20);
				} else {
					scoreController.RemovePoins (10);
				}
			}
		}
	}

	void changeSprite() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite) sprites[Random.Range(0, 9)];
	}

	void UpdateTimer() {
		if (gameObject == GameObject.Find ("target")) {
			timer = Random.Range (3, 5);
		} else {
			timer = Random.Range (1, 2);
		}
	}

	void StartClickAnimation() {
		Vector3 parentTransform = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -1);
		GameObject clone = Instantiate (clickAnimation, parentTransform, Quaternion.identity);
		Destroy (clone, 0.25f);
	}
}
