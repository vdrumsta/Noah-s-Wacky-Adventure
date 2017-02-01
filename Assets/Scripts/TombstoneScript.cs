using UnityEngine;
using System.Collections;

public class TombstoneScript : MonoBehaviour {

	public GameObject tombstoneDialogBox;
	public GameObject tombstoneText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			tombstoneDialogBox.SetActive (true);
			tombstoneText.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			tombstoneDialogBox.SetActive (false);
			tombstoneText.SetActive (false);
		}
	}
}
