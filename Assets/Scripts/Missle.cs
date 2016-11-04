using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

	public float speed;
	Rigidbody2D rigid;
	public float y;
	public GameObject missle;
	public GameObject smoke;

	// Use this for initialization
	void Awake () {
		rigid = GetComponent<Rigidbody2D> ();


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
			rigid.velocity = Vector2.zero;
			smoke.GetComponent<ParticleSystem>().enableEmission = false;
		}
	}
}
