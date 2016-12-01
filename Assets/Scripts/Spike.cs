using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public int damage;
	public float force;
	float nextTime;
	public float timeDelay;
	Character player;
	public float pushTime;
	Sounds sounds;
	public AudioClip bounceSound;

	// Use this for initialization
	void Start () {
		nextTime = 0;
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			//player has entered spike
			bounce(other);
			other.GetComponent <Health>().hurt(damage);
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (Time.time>nextTime && other.tag == "Player"){
			other.GetComponent <Character> ().ResetJumps ();
			bounce (other);
			nextTime = Time.time + timeDelay;
		}
	}

	void bounce(Collider2D other){
		player = other.GetComponent<Character> ();
		other.GetComponent <Rigidbody2D>().velocity = Vector2.zero;
		Vector2 bounceDirection = Vector2FromAngle(transform.eulerAngles.z);
		print ("angle"+transform.eulerAngles.z);
		bounceDirection.Normalize ();
		player.push (bounceDirection, force, pushTime);
		print ("Vector"+bounceDirection);

		//play sound
		if (bounceSound!=null){
			sounds.doBounceSound (bounceSound);
			print ("bounce");
		}
	}

	Vector2 Vector2FromAngle(float a){
		a += 90;
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}
}
