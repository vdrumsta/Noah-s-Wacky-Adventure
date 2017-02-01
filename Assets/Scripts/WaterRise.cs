using UnityEngine;
using System.Collections;

public class WaterRise : MonoBehaviour {

	public bool riseWater;
	public float riseSpeed = 0.01f;
	public Player playerScript;
	public PauseMenu pauseMenuScript;
	public WinBox WinBoxScript;

	// Use this for initialization
	void Start () {
		riseWater = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (riseWater && !playerScript.dead && !pauseMenuScript.paused && !WinBoxScript.won) {
			transform.position += new Vector3 (0f, riseSpeed, 0f);
		}
	}
}
