using UnityEngine;
using System.Collections;

public class BloodFlash : MonoBehaviour {

	bool canFlash;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator>();
	}

	public void flash(){
		anim.SetTrigger ("Flash");
	}

}
