using UnityEngine;
using System.Collections;

public class MusicCheck : MonoBehaviour {

	public GameObject music;

	// Use this for initialization
	void Start () {
		if (!FindObjectOfType <MusicManager>()){
			Instantiate (music, transform.position, transform.rotation);
		}
	}

}
