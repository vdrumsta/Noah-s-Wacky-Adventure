using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectablePickup : MonoBehaviour {

	public Text collectableCountText;
	private int collectableCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Destroy (gameObject);
			collectableCount++;
			collectableCountText.text = "x " + collectableCount;
		}
	}
}
