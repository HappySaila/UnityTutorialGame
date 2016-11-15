using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float maxHealth;
	public float currentHealth;
	public GameObject particle;

	//health slider
	public Slider slider;
	public float smoothSlider;
	public float oldHealth;

	void Start(){
		currentHealth = maxHealth;

		//health slider
		slider.maxValue = maxHealth;
		slider.value = maxHealth;
		oldHealth = slider.value;
	}

	void Update(){
		if (currentHealth!=oldHealth){
			oldHealth = Mathf.Lerp (oldHealth, currentHealth, smoothSlider*Time.deltaTime);
			print (oldHealth);
			slider.value = oldHealth;
		}
	}

	public void hurt(int damage){
		oldHealth = currentHealth;
		currentHealth -= damage;

		if (currentHealth <= 0) {
			die ();
		}
	}

	void die(){
		if (particle != null) {
			Instantiate (particle, transform.position, transform.rotation);
		}
		Destroy (gameObject);
	}
}
