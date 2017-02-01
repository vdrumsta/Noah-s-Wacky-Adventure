using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	private Vector3 spawnPos; 
	public PlayerSpawn PlayerSpawnScript;

	// Use this for initialization
	void Start () {
		spawnPos.x = transform.position.x;
		spawnPos.y = transform.position.y;
		spawnPos.z = transform.position.z;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Debug.Log ("Checkpoint set");
			PlayerSpawnScript.SetSpawn (spawnPos);
		}
	}
}
