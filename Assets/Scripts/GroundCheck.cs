using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

	private Player player;
	private PlayerSpawn playerSpawn;
	private object otherObject;
	private AudioSource audioGround;
	public AudioClip grassLand;
	public AudioClip waterSplash;
	public PlayerSpawn spawnPos;
	//public Vector3 spawnPos;

    void Start()
    {
		//spawnPos = new Vector3 (-41, 52, 0);
		//playerSpawn = gameObject.(PlayerSpawn)();
		player = gameObject.GetComponentInParent<Player>();
		audioGround = GetComponent<AudioSource> ();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if (!player.grounded && col.gameObject.tag == "Grass") {
			audioGround.PlayOneShot(grassLand, 1.0F);
		}
        player.grounded = true;
		if(col.gameObject.tag == "TreeTop" || col.gameObject.tag == "Ladder"){
			player.transform.parent = col.transform;
		}

		if (col.gameObject.tag == "Water") {
			audioGround.PlayOneShot(waterSplash, 1.0F);
			player.dead = true;
		}
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
		player.canDoubleJump = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
		Invoke ("DelayUngrounding", 0.2f);
		player.transform.parent = null;
    }

	void DelayUngrounding () {
		player.grounded = false;
	}
}
