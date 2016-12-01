using UnityEngine;
using System.Collections;
using System.Configuration;

public class RocketTakeOff : MonoBehaviour {
	
	public GameObject character;
	public GameObject smoke;
	public GameObject camera;
	public float speed;
	public float maxSpeed;
	public float timeTilFade;
	public fading fader;

	levelManager LevelManager;
	Rigidbody2D rigid;
	public bool canTakeOff;
	CameraController cameraControl;

	Sounds sounds;


	// Use this for initialization
	void Start () {
		LevelManager = GameObject.Find ("LevelManager").GetComponent <levelManager>();
		cameraControl = camera.GetComponent <CameraController> ();
		rigid = GetComponent <Rigidbody2D> ();
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canTakeOff) {
			//apply thrusters
			rigid.AddForce (Vector2.up * speed, ForceMode2D.Force);
			if (rigid.velocity.magnitude > maxSpeed){
				rigid.velocity = new Vector2 (0, maxSpeed);
			}

			//count down till screen fades
			if (Time.time > timeTilFade){
				fader.canFadeOut = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			if (LevelManager.canFinish ()){
				takeOff ();
			}
		}
	}

	void takeOff(){
		canTakeOff = true;
		character.SetActive (false);
		smoke.SetActive(true);

		//set camera to lock onto the rocket
		cameraControl.setSmooth (100);
		cameraControl.setTarget (gameObject);

		timeTilFade += Time.time;

		sounds.doTakeOff ();
		PlayerPrefs.SetInt ("LevelNumber", LevelManager.levelNumber+1);

	}
}
