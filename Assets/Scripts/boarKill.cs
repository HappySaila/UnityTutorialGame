using UnityEngine;
using System.Collections;

public class boarKill : MonoBehaviour {

	public GameObject boarObject;
	public GameObject gameSounds;
	Sounds sounds;

	// Use this for initialization
	void Start () {
		sounds = gameSounds.GetComponent <Sounds> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (boarObject == null){
			Destroy (gameObject);
			sounds.doDie ();
		}
	}
}
