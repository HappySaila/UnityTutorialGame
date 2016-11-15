using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine.UI;

public class healthSlider : MonoBehaviour {

	float currentValue;
	float maxValue;
	public GameObject character;
	Slider slider;
	Health playerHealth;

	float tempHealth;

	//color flash
	public Image bloodFlash;
	Color bloodColor;
	public bool damage;
	public float flashRate;
	Color currentBlood;

	void Start(){
		slider = GetComponent <Slider> ();
		playerHealth = character.GetComponent <Health> ();
		slider.maxValue = playerHealth.maxHealth;
		bloodColor = new Color (1f,0f,0f,1f);
		tempHealth = playerHealth.currentHealth;
		currentBlood = Color.clear;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = playerHealth.currentHealth;

		if(tempHealth>playerHealth.currentHealth){
			tempHealth = playerHealth.currentHealth;
			damage = true;
			float healthRatio = 1 - ((float)playerHealth.currentHealth / playerHealth.maxHealth);
			print (healthRatio);
			print (currentBlood); 
			currentBlood = new Color (1f,0f,0f,healthRatio);
		}


		if (damage) {
			bloodFlash.color = bloodColor;
			damage = false;
		} else {
			bloodFlash.color = Color.Lerp (bloodFlash.color, currentBlood, flashRate*Time.deltaTime);
		}
	}
}
