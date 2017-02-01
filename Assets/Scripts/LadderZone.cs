using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	public Player player;
	public AnimalPickUp animalPickUpScript;
	public Animator animationSwing;

	// Use this for initialization
	void Start () {
		animationSwing = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player" && animalPickUpScript.pickedUp) {
			player.onLadder = true;
			animationSwing.SetBool ("Swing", true);

			Rigidbody2D rb2d = player.GetComponent<Rigidbody2D> ();
			rb2d.velocity = new Vector2 (0f, 0f);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.name == "Player" && animalPickUpScript.pickedUp) {
			player.onLadder = false;
			animationSwing.SetBool ("Swing", false);
		}
	}
}
