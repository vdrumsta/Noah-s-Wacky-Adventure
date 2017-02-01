using UnityEngine;
using System.Collections;

public class WinBox : MonoBehaviour {

	private Player player;
	public AnimalPickUp AnimalPickUpScript;
	public GameObject WinUI;
	public bool won;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (AnimalPickUpScript.pickedUp && col.gameObject.tag == "Player") {
			won = true;
			Time.timeScale = 0;
			WinUI.SetActive (true);
		}

	}
}
