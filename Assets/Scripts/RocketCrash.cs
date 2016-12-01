using UnityEngine;
using System.Collections;
using System.Threading;

public class RocketCrash : MonoBehaviour {

	Vector2 direction;
	Rigidbody2D rigid;
	Health health;
	ParticleSystem particleSystem;
	CameraController cameraControl;



	public bool crashed;
	public Transform target; //where the rocket will crash
	public float speed;
	public Sprite crashedSprite;
	public GameObject character;
	public GameObject particles;
	public GameObject camera;
	public Transform playerSpawnPosition;

	Sounds sounds;

	// Use this for initialization
	void Start () {
		//instantiate
		rigid = GetComponent <Rigidbody2D> ();
		health = GetComponent <Health> ();
		particleSystem = particles.GetComponent <ParticleSystem> ();
		cameraControl = camera.GetComponent <CameraController> ();

		//set trajectory
		direction = target.transform.position - transform.position;
		direction.Normalize ();

		//get sound component
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();
		sounds.doTakeOff ();
	}

	// Update is called once per frame
	void Update () {
		if (!crashed){
			rigid.velocity = direction * speed;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Explode Area"){
			explode ();
		}
	}

	void explode(){
		//the rocket has hit the ground
		transform.position = target.position;
		crashed = true;
		rigid.isKinematic = true;
		health.hurt (10);

		//remove rocket
		GetComponent <SpriteRenderer> ().enabled = false;
		particleSystem.enableEmission = false;

		//shootplayer in the air
		character.SetActive (true);
		character.transform.position = transform.position;
		character.GetComponent <Character>().push (new Vector2(0.2f, 1), 15, 1.5f);
		character.GetComponent <Health> ().hurt (99);

		//set cameras target to the player
		cameraControl.setTarget(character);
		cameraControl.setSmooth (3);

		//play explode sound
		sounds.doRocketCrash();

		//set spawn position
		character.GetComponent <Character>().resetPosition (playerSpawnPosition.position);


	}
		
}
