using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {
	public SpriteRenderer lightning1;
	public SpriteRenderer lightning2;
	SpriteRenderer currentLightning;

	public void FlashLightning () {
		AudioSource audio;
		audio = GetComponent<AudioSource> ();
		audio.Play();

		currentLightning = lightning1;
		EnableLightning();
		Invoke ("EnableLightning", 0.2f);
		Invoke ("EnableLightning", 0.4f);
	}

	void EnableLightning () {
		currentLightning.enabled = true;
		Invoke ("DisableLightning", 0.1f);
	}

	void DisableLightning () {
		currentLightning.enabled = false;
		if (currentLightning == lightning1) {
			currentLightning = lightning2;
		} else {
			currentLightning = lightning1;
		}
	}
}
