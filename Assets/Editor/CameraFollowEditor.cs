using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraController))]
public class CameraFollowEditor : Editor {

	// Use this for initialization
	public override void OnInspectorGUI () {
		DrawDefaultInspector ();

		CameraController cameraControl = (CameraController)target;

		if (GUILayout.Button("Set min Position")){
			//creating button and checking if it is pressed
			cameraControl.setMinCameraPosition();
		}

		if (GUILayout.Button("Set max Position")){
			//creating button and checking if it is pressed
			cameraControl.setMaxCameraPosition();
		}

	}
}
