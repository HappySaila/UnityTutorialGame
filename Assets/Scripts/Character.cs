using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	//movement
	public float maxSpeed;

	//jumping
	public Transform groundCheckPosition;
	bool grounded;
	public LayerMask groundLayer;
	public int jumpForce;

	Rigidbody2D rigid;
	Animator animator;
	bool facingRight;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;
	}

	void Update(){
		updateJumping ();
	}

	void updateJumping(){
		if (grounded && Input.GetAxis ("Vertical") > 0) {
			//we want to jump
			grounded = false;
			animator.SetBool ("grounded", grounded);
			rigid.AddForce (new Vector2 (0, jumpForce));
		}

	}
		
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxisRaw ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs(move));

		if (move > 0 && !facingRight) {
			flipSprite ();
		} else if (move < 0 && facingRight) {
			flipSprite ();
		}

		rigid.velocity = new Vector2(move*maxSpeed, rigid.velocity.y);

		grounded = Physics2D.OverlapCircle (groundCheckPosition.position, 0.1f, groundLayer);
		animator.SetFloat ("verticleSpeed", rigid.velocity.y);
		animator.SetBool ("grounded", grounded);

	}

	void flipSprite(){
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		facingRight = !facingRight;
	}

	public bool isFacingRight(){
		return facingRight;
	}

}
