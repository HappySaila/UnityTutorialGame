using UnityEngine;
using System.Collections;

public class boarKill : MonoBehaviour {

	public GameObject boarObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (boarObject == null){
			Destroy (gameObject);
		}
	}
}
