using UnityEngine;
using System.Collections;

public class StopRot : MonoBehaviour {


	// Update is called once per frame
	void Update () {
	
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
