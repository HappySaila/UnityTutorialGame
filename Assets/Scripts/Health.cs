using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Configuration;

public class Health : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public GameObject particle;
	public bool KeepObject;

	//health slider
	public Slider slider;
	public float smoothSlider;
	public float oldHealth;

	public GameObject[] DestroyWhenDie; //all objects that will be destroyed when this object dies
	public GameObject[] EnableWhenDie; //all objects that will be enabled when this object dies
	public GameObject[] DropWhenDie; //all objects that can be dropped when this object dies
	public BloodFlash flash;

	public float percentage;

	Sounds sounds;
	public AudioClip dieSound;

	private float healthLerpValue = 0f;

	void Start(){
		currentHealth = maxHealth;

		//health slider
		slider.maxValue = maxHealth;
		slider.value = maxHealth;
		oldHealth = slider.value;

		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();

		hurt (0);
	}

	void Update(){
		if (healthLerpValue <= 1f){
			healthLerpValue += smoothSlider * Time.deltaTime;
			oldHealth = Mathf.Lerp (oldHealth, currentHealth, healthLerpValue);

			slider.value = oldHealth;
		}
	}

	public void hurt(int damage){
		if (gameObject.tag == "Player" && damage>0){
			flash.flash ();
		}
		healthLerpValue = 0f;
		oldHealth = currentHealth;
		currentHealth -= damage;

		if (currentHealth <= 0) {
			die ();
		}

		if (currentHealth > maxHealth){
			currentHealth = maxHealth;
		}
	}

	void die(){
		if (particle != null) {
			Instantiate (particle, transform.position, transform.rotation);
		}

		if (!KeepObject){
			Destroy (gameObject);
		}
		foreach(GameObject g in DestroyWhenDie){
			Destroy (g);
		}

		foreach(GameObject g in EnableWhenDie){
			g.SetActive (true);
		}

		if (DropWhenDie.Length>0 && Random.Range (0,100) > 100 - percentage){
			GameObject drop = DropWhenDie[Random.Range (0, DropWhenDie.Length)];
			Instantiate (drop, transform.position, transform.rotation);
		}

		if (gameObject.tag == "Player"){
			GameObject.Find ("LevelManager").GetComponent <levelManager> ().reload ();
		}

		if (dieSound!=null){
			sounds.doDieSound (dieSound);
		}
	}
}
