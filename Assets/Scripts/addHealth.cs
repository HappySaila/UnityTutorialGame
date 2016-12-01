using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class addHealth : MonoBehaviour {

	public int amount; //amount of health to give to player
	public Sounds sounds;
	Health health;

	void Awake(){
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			
			Destroy (gameObject);
			health = collider.GetComponent <Health> ();
			health.hurt (-amount);

			sounds.doGetHealth ();
		}
	}
}
