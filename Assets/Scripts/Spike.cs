using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public int damage;
	public float force;
	float nextTime;
	public float timeDelay;
	Character player;

	// Use this for initialization
	void Start () {
		nextTime = 0;
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
			bounce (other);
			nextTime = Time.time + timeDelay;
		}
	}

	void bounce(Collider2D other){
		player = other.GetComponent<Character> ();
		other.GetComponent <Rigidbody2D>().velocity = Vector2.zero;
		player.push (new Vector2(0,1), force);
	}
}
