using UnityEngine;
using System.Collections;
using DigitalRuby.RainMaker;

public class AnimalPickUp : MonoBehaviour {

	public GameObject placePos; // pos where animal will be placed
	public WaterRise waterRiseScript;
	public Lightning lightningScript;
	private AudioSource audio;
	public AudioClip monkeyPickup;
	public RainScript2D rainScript2D;

	public bool pickedUp = false;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!pickedUp && col.gameObject.tag == "Player") {
			pickedUp = true;
			this.transform.position = placePos.transform.position;	// positions the aniaml on the placePos position
			this.transform.parent = col.gameObject.transform;		// attached the animal to the player

			waterRiseScript.riseWater = true;
			lightningScript.FlashLightning ();
			rainScript2D.RainIntensity = 1f;

			audio.PlayOneShot (monkeyPickup, 1f);
		}
	}
}
