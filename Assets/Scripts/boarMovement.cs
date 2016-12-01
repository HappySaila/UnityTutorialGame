using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boarMovement : MonoBehaviour {

	public Transform PositionA;
	public Transform PositionB;
	public Animator animator;
	public Rigidbody2D rigid;
	SpriteRenderer sprite;


	//flipping
	float nextFlip;
	public float flipDelay;
	public bool canFlip;
	bool facingRight;

	//charging
	public bool isCharge;
	public float chargeSpeed;

	//idling
	public Vector2 idlePosition;
	public float speed;

	// Use this for initialization
	void Start () {
		nextFlip = 0f;
		animator = GetComponent <Animator> ();
		rigid = GetComponent <Rigidbody2D> ();
		idlePosition = new Vector2 (transform.position.x, transform.position.y);
		sprite = GetComponent <SpriteRenderer> ();
		sprite.flipX = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canFlip){
			updateFlip ();
		}

		if (isCharge) {
			charge ();
		} else {
			//return to idle position
			returnToIdle();
		}
	}

	void updateFlip(){
		if (Time.time > nextFlip) {
			if (Random.Range (0,10) >= 5){
				flip ();
			}
		}
	}

	public void flip(){
		//will flip the sprite
		sprite.flipX = !sprite.flipX;
//		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		facingRight = !facingRight;
		nextFlip = Time.time + flipDelay;
	}

	void charge(){
		if (facingRight) {
			//charge to the right
			rigid.velocity = new Vector2(1*chargeSpeed, rigid.velocity.y);
		} else {
			//charge to the left
			rigid.velocity = new Vector2(-1 * chargeSpeed,rigid.velocity.y);
		}

		checkCharge ();
	}

	void checkCharge(){
		if (facingRight) {
			if (transform.position.x > PositionB.transform.position.x){
				isCharge = false;
				animator.SetBool ("isCharge", isCharge);
				flip ();
			}
		} else {
			if (transform.position.x < PositionA.transform.position.x){
				isCharge = false;
				animator.SetBool ("isCharge", isCharge);
				flip ();
			}
		}
	}

	public bool isFacingRight(){
		return facingRight;
	}

	void returnToIdle(){
		if (facingRight) {
			//charge to the right
			rigid.velocity = new Vector2(1*speed, rigid.velocity.y);
		} else {
			//charge to the left
			rigid.velocity = new Vector2(-1 * speed,rigid.velocity.y);
		}

		checkCharge ();
	}
}
