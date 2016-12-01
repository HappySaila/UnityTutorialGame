using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public Image health;
	public Image bullets;

	public Text healthText;
	public Text bulletText;

	MissleLauncher missleLauncher;
	Health healthScript;

	float currentHealthAmount;
	float currentBulletsAmount;
	public float smoothing;


	// Use this for initialization
	void Start () {
		missleLauncher = GetComponent <MissleLauncher> ();
		healthScript = GetComponent <Health> ();

		currentHealthAmount = (float)healthScript.currentHealth;
		currentBulletsAmount = (float)missleLauncher.bullets;
	}
	
	// Update is called once per frame
	void Update () {
		updateBullets ();
		updateHealth ();
	}

	void updateHealth(){
		float fillAmount = (float) healthScript.currentHealth / healthScript.maxHealth;
		updateHealthColor (fillAmount);
		currentHealthAmount = Mathf.Lerp (currentHealthAmount, fillAmount, Time.deltaTime*smoothing);

		//update text
		if (currentHealthAmount>0.99){
			currentHealthAmount = 1;
		}
		healthText.text = "Health: " + (int) (currentHealthAmount*healthScript.maxHealth) + "%";

		health.fillAmount = currentHealthAmount;
	}

	void updateHealthColor(float fillAmount){
		if (fillAmount > 0.5) {
			byte fillValue = (byte)(255 - (fillAmount * 255));
			Color32 colorTarget = new Color32 (fillValue, 255, 0, 255);
			health.color = Color.Lerp (health.color, colorTarget, Time.deltaTime * smoothing);
		} else {
			byte fillValue = (byte)(fillAmount * 2 * 255);
			Color32 colorTarget = new Color32 (255, fillValue, 0, 255);
			health.color = Color.Lerp (health.color, colorTarget, Time.deltaTime * smoothing);
		}
	}

	void updateBulletColor(float fillAmount){
		byte fillValue = (byte)(fillAmount*255);
		Color32 colorTarget = new Color32 (255, 0, fillValue, 255);
		bullets.color = Color.Lerp (bullets.color, colorTarget, Time.deltaTime * smoothing);
	}

	void updateBullets(){
		float fillAmount = (float) missleLauncher.bullets / missleLauncher.maxBullets;
		updateBulletColor (fillAmount);
		currentBulletsAmount = Mathf.Lerp (currentBulletsAmount, fillAmount, Time.deltaTime*smoothing);
		bullets.fillAmount = currentBulletsAmount;

		//update text
		if (currentBulletsAmount>0.99){
			currentBulletsAmount = 1;
		}
		bulletText.text = "Bullets: " + (int) (currentBulletsAmount*missleLauncher.maxBullets);
	}
}
