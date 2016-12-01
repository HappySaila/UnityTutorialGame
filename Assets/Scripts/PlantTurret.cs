using UnityEngine;
using System.Collections;

public class PlantTurret : MonoBehaviour {

	public int shootPercent;
	public float shootDelay;
	float nextShoot;
	public int searchRadius;

	public GameObject spore;
	public Transform shootPosition;

	CircleCollider2D  collider;
	public Animator animator;

	Sounds sounds;


	// Use this for initialization
	void Start () {
		nextShoot = 0;
		collider = gameObject.AddComponent <CircleCollider2D>() as CircleCollider2D;
		collider.radius = searchRadius;
		collider.isTrigger = true;

		animator = GetComponent <Animator> ();
		sounds= GameObject.Find ("GameSounds").GetComponent <Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D collider){
		if (Time.time > nextShoot && collider.tag == "Player"){
			//shoot a spore
			sounds.doPlantSpit ();
			nextShoot = Time.time + shootDelay;
			if (Random.Range (0,100) > 100-shootPercent){
				Instantiate (spore, shootPosition.position, shootPosition.rotation);
				animator.SetTrigger ("Shoot");
			}
		}
	}
}
