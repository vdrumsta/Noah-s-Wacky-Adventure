using UnityEngine;
using System.Collections;

public class MoveVineOptions : MonoBehaviour {

	public Animator animationSwing;
	public float speedSwing;

	void Start (){
	
		animationSwing = GetComponent<Animator>();
		animationSwing.SetFloat ("SpeedMulti", speedSwing);
	}




}
