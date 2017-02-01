using UnityEngine;
using System.Collections;

public class ResetPlayerPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetPos () {
		PlayerPrefs.SetFloat("spawnPosX", 0);
		PlayerPrefs.SetFloat("spawnPosY", 0);
		PlayerPrefs.SetFloat("spawnPosZ", 0);
		PlayerPrefs.Save ();
	}
}
