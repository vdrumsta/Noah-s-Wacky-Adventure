using UnityEngine;
using System.Collections;

public class WaterWheel : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {

		transform.Rotate(0, 0 , -1);
	}
}
