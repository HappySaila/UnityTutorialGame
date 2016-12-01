using UnityEngine;
using System.Collections;
using System.Threading;

public class Spore : MonoBehaviour {

	public int maxHeight;
	public int minHeight;
	public int angle;
	public int torque;
	Rigidbody2D rigid;


	// Use this for initialization
	void Start () {
		rigid = GetComponent <Rigidbody2D>();

		int x = Random.Range (0, angle);
		int y = Random.Range (minHeight, maxHeight);
		int t = Random.Range (0, torque);

		GameObject player = GameObject.Find ("character");

		if (player.transform.position.x > transform.position.x) {
			//player is on the right
			rigid.AddForce (new Vector2 (x, y), ForceMode2D.Impulse);
			rigid.AddTorque (t, ForceMode2D.Impulse);
		} else {
			rigid.AddForce (new Vector2 (-x, y), ForceMode2D.Impulse);
			rigid.AddTorque (-t, ForceMode2D.Impulse);
			//player is on the left
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
