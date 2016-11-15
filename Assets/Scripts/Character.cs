using UnityEngine;
using System.Collections;
using System.Text;

public class Character : MonoBehaviour {

	//movement
	public float maxSpeed;

	//jumping
	public Transform groundCheckPosition;
	bool grounded;
	public LayerMask groundLayer;
	public int jumpForce;
	public GameObject dustCloud;

	//double jumping
	bool canDoubleJump;
	float nextdoubleJump;
	float doubleJumpDelay;
	public int numberDoubleJumps;
	int currentJumps;
	public bool infiniteJump;

	Rigidbody2D rigid;
	Animator animator;
	bool facingRight;
	float yDiePosition;

	//sounds
	public GameObject Sounds;
	Sounds sounds;

	Vector3 startPosition;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;
		startPosition = transform.position;
		yDiePosition = transform.position.y - 50;
		sounds = Sounds.GetComponent <Sounds> ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Q)) {
			transform.position = startPosition;
		}
		updateJumping ();
		updatePosition ();
	}

	void updateJumping(){
		if (grounded && Input.GetAxis ("Vertical") > 0) {
			//we want to jump
			grounded = false;
			animator.SetBool ("grounded", grounded);
			Jump (false);
			canDoubleJump = false;
		}

		if (Time.time > nextdoubleJump){
			if (Input.GetAxisRaw ("Vertical") > 0 && currentJumps < numberDoubleJumps && canDoubleJump){
				nextdoubleJump = Time.time + doubleJumpDelay;
				currentJumps++;
				Jump (true);
				canDoubleJump = false;
			}
		}

		if (grounded){
			currentJumps = 0;
		}

		if (Input.GetAxisRaw ("Vertical") == 0){
			canDoubleJump = true;
		}
	}

	void Jump(bool doubleJump){
		//play jump sound
		if (!doubleJump) {
			sounds.doDoubleJump ();
		} else {
			sounds.doJump();
		}

		//jump force
		rigid.velocity = Vector2.zero;
		rigid.AddForce (new Vector2 (0, jumpForce));
		Instantiate (dustCloud, groundCheckPosition.position, Quaternion.Euler (new Vector3 (0,0,180)));
		Instantiate (dustCloud, groundCheckPosition.position, transform.rotation);
		nextdoubleJump = Time.time + doubleJumpDelay;
		if (infiniteJump){
			currentJumps = 0;
		}
	}

	void updatePosition(){
		if (transform.position.y < yDiePosition) {
			transform.position = startPosition;
			rigid.velocity = Vector2.zero;
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

	public void push(Vector3 direction, float force){
		Vector2 forceDirection = new Vector2 (direction.x, direction.y);
		rigid.AddForce (forceDirection*force, ForceMode2D.Impulse);
	}
}
