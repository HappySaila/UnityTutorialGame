using UnityEngine;
using System.Collections;
public class CheckPoint : MonoBehaviour {

	Animator anim;
	bool Checked;

	void Start(){
		anim = GetComponent <Animator> ();
		Checked = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			resetPosition (other);
			Checked = true;
			anim.SetBool ("Checked", Checked);
		}
	}

	void resetPosition(Collider2D other){
		Character player = other.GetComponent <Character> ();
		player.resetPosition (transform.position);
	}
}
