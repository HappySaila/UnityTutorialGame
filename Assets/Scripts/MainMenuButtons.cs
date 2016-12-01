using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	MusicManager music;
	public static int level = 0;
	
	// Use this for initialization
	void Start () {
		if (GameObject.Find("MusicManager")){
			music= GameObject.Find ("MusicManager").GetComponent <MusicManager>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartClicked(){
		int SceneToLoad = PlayerPrefs.GetInt ("LevelNumber");
		SceneManager.LoadScene ("Level"+(SceneToLoad+1));
		music.loadTrack (1);
	}

	public void LevelSelectClicked(){
		SceneManager.LoadScene ("Level Select");
	}

	public void ExitClicked(){
		Application.Quit ();
	}

	public void BackClicked(){
		SceneManager.LoadScene ("MainMenu");
	}
}
