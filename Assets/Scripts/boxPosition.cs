using UnityEngine;
using System.Collections;

public class boxPosition : MonoBehaviour {

	BoxCollider2D collider;
	public GameObject boar;
	boarMovement boarMovement;
	public Transform PositionA;
	public Transform PositionB;

	Sounds sounds;


	// Use this for initialization
	void Start () {
		collider = GetComponent <BoxCollider2D> ();
		float boxSize = Mathf.Abs (PositionA.position.x - PositionB.position.x);
		collider.size = new Vector2 (boxSize, collider.size.y);
		collider.offset = new Vector2 (PositionA.localPosition.x + boxSize/2, 0);

		boarMovement = boar.GetComponent <boarMovement> ();
		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			//flip sprite to correct direction before charging
			if (!boarMovement.isCharge) {
				
				if (other.transform.position.x < boar.transform.position.x) {
					//flip boar to face left
					if (boarMovement.isFacingRight ()) {
						boarMovement.flip ();
					}
				} else {
					//flip the boar to face right
					if (!boarMovement.isFacingRight ()){
						boarMovement.flip ();
					}
				}

				sounds.doBoarGrunt ();
			}

			boarMovement.isCharge = true;
			boarMovement.animator.SetBool ("isCharge", boarMovement.isCharge);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		OnTriggerEnter2D (other);
	}
}
