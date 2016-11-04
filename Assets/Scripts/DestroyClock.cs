using UnityEngine;
using System.Collections;

public class DestroyClock : MonoBehaviour {

	public int aliveTimer;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, aliveTimer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
