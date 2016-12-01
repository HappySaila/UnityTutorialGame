using UnityEngine;
using System.Collections;

public class defaultBullet : MonoBehaviour {

	public Character player;
	public int speed;
	public int damage;
	public GameObject explosion;

	Vector2 direction;
	public Rigidbody2D rigid;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("character").GetComponent <Character> ();

		if (player.isFacingRight ()) {
			direction = new Vector2 (1, 0);
		} else {
			direction = new Vector2 (-1, 0);
		}

		rigid = GetComponent <Rigidbody2D>();
	}
		
	
	// Update is called once per frame
	void FixedUpdate () {
		rigid.velocity = direction * speed;
	}

	void OnTriggerEnter2D (Collider2D collider){
		if (collider.tag == "object"){
			collider.GetComponent <Health>().hurt(damage);
		}

		if (collider.gameObject.layer != LayerMask.NameToLayer ("MissleIgnore")){
			Destroy (gameObject);
		}

		if (explosion!=null){
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
}
