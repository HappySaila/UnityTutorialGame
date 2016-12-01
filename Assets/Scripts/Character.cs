using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.EventSystems;
using System.ComponentModel;
using UnityStandardAssets.CrossPlatformInput;
using System.Security.Cryptography;

public class Character : MonoBehaviour {

	//movement
	public float maxSpeed;
	public float moveForce;
	bool canMove;
	float canMoveTime;

	float nextStep;
	public float stepDelay;

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
	Sounds sounds;

	Vector3 startPosition;
	public bool buildingMode;

	//touch input movement booleans
	public bool upPressed;
	public bool downPressed;


	// Use this for initialization
	void Start () {
		//check if there is a character in the scene

		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		facingRight = true;
		yDiePosition = transform.position.y - 50;
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds> ();
		canMove = false;
		if (!buildingMode){
			gameObject.SetActive (false);
		}
	}
			

	void Update(){
		updateJumping ();
		updatePosition ();

	}

	void updateJumping(){
		if (grounded && (Input.GetAxis ("Vertical") > 0 || upPressed)) {
			//we want to jump
			grounded = false;
			animator.SetBool ("grounded", grounded);
			Jump (false);
			canDoubleJump = false;
		}

		if (Time.time > nextdoubleJump){
			if ((Input.GetAxis ("Vertical") > 0 || upPressed) && currentJumps < numberDoubleJumps && canDoubleJump){
				nextdoubleJump = Time.time + doubleJumpDelay;
				currentJumps++;
				Jump (true);
				canDoubleJump = false;
			}
		}

		if (grounded){
			ResetJumps ();
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
		//sets the movement to normal input unless cross platform input detected
		float move = (CrossPlatformInputManager.GetAxis ("Horizontal")!=0 ? 
			CrossPlatformInputManager.GetAxisRaw ("Horizontal") : Input.GetAxisRaw ("Horizontal"));
		
		animator.SetFloat ("speed", Mathf.Abs(move));

		if (move > 0 && !facingRight) {
			flipSprite (); 
		} else if (move < 0 && facingRight) {
			flipSprite ();
		}

		updateMovement (move);

		grounded = Physics2D.OverlapCircle (groundCheckPosition.position, 0.1f, groundLayer);
		animator.SetFloat ("verticleSpeed", rigid.velocity.y);
		animator.SetBool ("grounded", grounded);
	}

	void updateMovement(float move){
		if (move>0){
			move = 1;
		}
		if (canMove) {
			if (move != 0) {
				rigid.velocity = new Vector2 (move * maxSpeed, rigid.velocity.y);
			} else {
				rigid.velocity = new Vector2 (0, rigid.velocity.y);
			}
		} else {
			//player can not move
			if (Time.time > canMoveTime){
				canMove = true;
			}
		}

		//movement sounds
		if (Time.time > nextStep && move!=0 && grounded){
			nextStep = Time.time + stepDelay;
			sounds.doFootStep ();
			print ("Step");
		}
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

	public void push(Vector2 direction, float force, float time){
		rigid.AddForce (direction*force, ForceMode2D.Impulse);
		stopMovement (time);
		currentJumps = 0;
		canMove = false;
	}

	public void ResetJumps(){
		currentJumps = 0;
	}

	public void stopMovement(float timer){
		//player can not move for x amount of time
		canMove = false;
		canMoveTime = timer + Time.time;
	}

	public void resetPosition(Vector2 position){
		startPosition = position;
	}

	public void touchJump(){
		print ("Jump");
		upPressed = true;
		StartCoroutine (resetJumpButton ());
	}

	IEnumerator resetJumpButton(){
		yield return new WaitForEndOfFrame ();
		upPressed = false;
	}

	public void touchShoot(){
		downPressed = true;
	}

	public void releaseShoot(){
		downPressed = false;
	}

}
