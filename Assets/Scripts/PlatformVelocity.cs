using UnityEngine;
using System.Collections;

public class PlatformVelocity : MonoBehaviour {

	private Rigidbody2D rb2d;

	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
		velocity = rb2d.velocity;
	}

	public Vector3 getVel(){

		return velocity;
	}
}
