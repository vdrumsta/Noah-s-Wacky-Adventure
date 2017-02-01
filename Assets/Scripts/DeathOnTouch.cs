using UnityEngine;
using System.Collections;

public class DeathOnTouch : MonoBehaviour {

	private Player player;

	// Checks if player touches object and then kills them
	void Start()
	{
		player = gameObject.GetComponentInParent<Player>();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		player.dead = true;
	}

}
