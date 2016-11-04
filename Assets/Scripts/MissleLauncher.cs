using UnityEngine;
using System.Collections;

public class MissleLauncher : MonoBehaviour {

	public float fireDelay;
	public Character character;
	float nextFire;
	public Transform firePosition;
	public GameObject bullet;


	// Use this for initialization
	void Start () {
		character = GetComponent<Character> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Vertical") < 0) {
			fireWeapon ();
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
		}
	}
		
}
