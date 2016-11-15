using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;
	public Transform target; //player we want to follow
	public float smoothing;
	public float trailPosition;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			transform.position = Vector3.Lerp (transform.position, target.position + new Vector3(0,0,trailPosition), 
				smoothing*Time.deltaTime);
			
			updateCameraPosition ();
		}
	}

	void updateCameraPosition(){
		//setting camera bounds
		if (transform.position.x < minCameraPos.x){
			transform.position = new Vector3(minCameraPos.x, transform.position.y, trailPosition);
		}

		if (transform.position.y < minCameraPos.y){
			transform.position = new Vector3(transform.position.x, minCameraPos.y, trailPosition);
		}

		if (transform.position.x > maxCameraPos.x){
			transform.position = new Vector3(maxCameraPos.x, transform.position.y, trailPosition);
		}

		if (transform.position.y > maxCameraPos.y){
			transform.position = new Vector3(transform.position.x, maxCameraPos.y, trailPosition);
		}
	}

	public void setMinCameraPosition(){
		minCameraPos = transform.position;
	}

	public void setMaxCameraPosition(){
		maxCameraPos = transform.position;
	}
}
