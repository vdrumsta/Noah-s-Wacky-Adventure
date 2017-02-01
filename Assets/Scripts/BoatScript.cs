using UnityEngine;
using System.Collections;

public class BoatScript : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> (); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D other) {
		if (other.tag == "Water") {
			rb2d.AddForce (new Vector2 (0, 100), ForceMode2D.Force);
		}
	}
}
