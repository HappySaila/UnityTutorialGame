using UnityEngine;
using System.Collections;

public class triggerDelete : MonoBehaviour {

	public GameObject destroyAnim;

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Destroy (gameObject);
			if (destroyAnim != null){
				Instantiate (destroyAnim, transform.position, transform.rotation);
			}
		}
	}
}
