using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	public float maxSpeed;
	Rigidbody2D rigid;
	Animator animator;
	bool facingRight;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		maxSpeed = 5;
		facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs(move));

		if (move > 0 && !facingRight) {
			flipSprite ();
		} else if (move < 0 && facingRight) {
			flipSprite ();
		}

		if (move != 0){
		}
		rigid.velocity = new Vector2(move*maxSpeed, rigid.velocity.y);

	}

	void flipSprite(){
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		facingRight = !facingRight;
	}

}
