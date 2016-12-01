using UnityEngine;
using System.Collections;

public class BulletPickup : MonoBehaviour {

	public int amount; //amount of ammo to give to player
	MissleLauncher launcher;
	Sounds sounds;

	void Awake(){
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Destroy (gameObject);
			launcher = collider.GetComponent <MissleLauncher> ();
			launcher.load (amount);

			sounds.doGetAmmo ();
		}
	}
}
