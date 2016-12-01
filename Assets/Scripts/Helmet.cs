using UnityEngine;
using System.Collections;

public class Helmet : MonoBehaviour {

	levelManager levelManager;

	// Use this for initialization
	void Awake () {
		levelManager = GameObject.Find ("LevelManager").GetComponent <levelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player"){
			Character player = collider.GetComponent <Character> ();
			levelManager.helmetCollected ();
			Destroy (gameObject);
		}
	}
}
