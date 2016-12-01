using UnityEngine;
using System.Collections;
using System.Net;

public class cannonFire : MonoBehaviour {

	public GameObject player;
	public GameObject bullet;

	public Transform fireOut1;
	public Transform fireOut2;
	Transform currentOut;

	public float fireDelay;
	public float fireNextTime;

	Sounds sounds;
	Animator animator;


	// Use this for initialization
	void Start () {
		currentOut = fireOut1;
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds> ();
		animator = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D (Collider2D collider){
		if (collider.tag == "Player"){
			Fire ();
		}
	}

	void Fire(){
		if (Time.time > fireNextTime){
			animator.SetTrigger ("fire");
			fireNextTime = Time.time + fireDelay;
			Instantiate (bullet, currentOut.transform.position, transform.rotation);

			if (currentOut == fireOut1){
				currentOut = fireOut2;

			}else{
				currentOut = fireOut1;
			}

			sounds.doCannonFire ();
		}
	}
}
