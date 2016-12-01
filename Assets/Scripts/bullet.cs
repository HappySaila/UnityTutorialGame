using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	bool travelRight;
	Vector2 direction;

	public float speed;
	public int damage;
	public Rigidbody2D rigid;

	public GameObject bulletObject;
	public GameObject smoke;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("character").transform.position.x < transform.position.x) {
			//travelLeft
			travelRight = false;
			direction = new Vector2 (-1,0);
		} else {
			travelRight = true;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, 0);
			direction = new Vector2 (1,0);
		}

		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigid.velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer != LayerMask.NameToLayer ("MissleIgnore")){
			Destroy (bulletObject);
			smoke.GetComponent<ParticleSystem> ().enableEmission = false;
			Destroy (gameObject, 0.2f);
			if (explosion!=null){
				Instantiate (explosion, transform.position, transform.rotation);
			}
		}

		if (other.tag == "Player"){
			other.GetComponent <Health>().hurt (damage);
		}
	}
}
