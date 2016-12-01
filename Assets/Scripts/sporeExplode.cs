using UnityEngine;
using System.Collections;

public class sporeExplode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int x = Random.Range (0, 360);
		int y = Random.Range (0, 360);
		int z = Random.Range (0, 360);
		transform.rotation = Quaternion.Euler (new Vector3 (x,y,z));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
