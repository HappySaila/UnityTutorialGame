using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

	public float speed;
	Rigidbody2D rigid;
	public float y;
	public GameObject missle;
	public GameObject smoke;
	public GameObject explosion;
	public int damage;

	bool destroyed;

	//sounds
	//sounds
	public GameObject Sounds;
	Sounds sounds;

	void Start(){
		sounds = Sounds.GetComponent <Sounds> ();
	}

	// Use this for initialization
	void Awake () {
		Sounds = GameObject.Find ("GameSounds");
		rigid = GetComponent<Rigidbody2D> ();
		sounds = Sounds.GetComponent <Sounds> ();


		if (transform.localRotation.z>0){
			//fire left
			rigid.AddForce(new Vector2(-1,0)*speed, ForceMode2D.Impulse);
		}else{
			//fire right
			rigid.AddForce(new Vector2(1,0)*speed, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (missle == null) {
			if (!destroyed) {
				rigid.velocity = Vector2.zero;
				smoke.GetComponent<ParticleSystem> ().enableEmission = false;
				Instantiate (explosion, transform.position, transform.rotation);
				destroyed = true;
				Destroy (gameObject, 0.2f);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.layer != LayerMask.NameToLayer ("MissleIgnore")) {
			//missle must explode
			sounds.doRocketHit ();
			Destroy(missle);
		}

		if (collider.tag == "object") {
			collider.GetComponent <Health>().hurt(damage);
			sounds.doRocketHit ();
		}
	}
}
