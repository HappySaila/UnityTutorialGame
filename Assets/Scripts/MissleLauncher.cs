using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MissleLauncher : MonoBehaviour {

	public float fireDelay;
	public float defaultFireDelay;

	public Character character;
	float nextFire;
	public Transform firePosition;
	public GameObject bullet;
	public GameObject bulletDefault;

	public int bullets;
	public int maxBullets;

	//sounds
	public GameObject Sounds;
	Sounds sounds;


	// Use this for initialization
	void Start () {
		character = GetComponent<Character> ();
		sounds = Sounds.GetComponent <Sounds> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") < 0 || character.downPressed) {
			if (bullets > 0) {
				fireWeapon ();
			} else {
				fireDefault ();
			}
		}
	}

	void fireDefault(){
		if (Time.time > nextFire) {
			nextFire = Time.time + defaultFireDelay;
			if (character.isFacingRight()) {
				Instantiate (bulletDefault, firePosition.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else {
				Instantiate (bulletDefault, firePosition.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
			sounds.doDefaultShoot ();
		}
	}

	void fireWeapon(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireDelay;
			if (character.isFacingRight()) {
				Instantiate (bullet, firePosition.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			} else {
				Instantiate (bullet, firePosition.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));
			}
			bullets--;
			sounds.doRocketfire ();
			sounds.doRocketAir ();
		}
	}

	public void load(int amount){
		bullets += amount;
		if (bullets>maxBullets){
			bullets = maxBullets;
		}
	}
		
}
