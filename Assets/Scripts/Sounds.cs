using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Sounds : MonoBehaviour {

	public AudioClip jump;
	public AudioClip doubleJump;
	public AudioClip hurt;
	public AudioClip rocketFire;
	public AudioClip rocketAir;
	public AudioClip rocketHit;
	public bool playerOn;

	AudioSource player;




	// Use this for initialization
	void Start () {
		player = GetComponent <AudioSource> ();
		if (!playerOn){
			player.volume = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void doJump(){
		player.PlayOneShot (jump);
	}

	public void doDoubleJump(){
		player.PlayOneShot (doubleJump);
	}

	public void doHurt(){
		player.PlayOneShot (hurt);
	}

	public void doRocketfire(){
		player.PlayOneShot (rocketFire);
	}

	public void doRocketAir(){
		player.PlayOneShot (rocketAir);
	}

	public void doRocketHit(){
		player.PlayOneShot (rocketHit);
	}
}
