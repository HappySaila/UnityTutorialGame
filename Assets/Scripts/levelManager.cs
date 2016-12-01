using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class levelManager : MonoBehaviour {

	public int HelmetsToCollect;
	public int levelNumber;
	int helmetsCollected;

	public Text HelmetText;
	public Image HelmetImage;

	Sounds sounds;
	MusicManager music;

	// Use this for initialization
	void Start () {

		sounds = GameObject.Find ("GameSounds").GetComponent <Sounds>();
		if (GameObject.Find ("MusicManager")){
			music = GameObject.Find ("MusicManager").GetComponent <MusicManager>();
		}

		if (HelmetText!=null){
			HelmetText.text = helmetsCollected + "/" + HelmetsToCollect;
		}
			


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void helmetCollected(){
		helmetsCollected++;
		HelmetText.text = helmetsCollected + "/" + HelmetsToCollect;
	}

	public bool canFinish(){
		if(helmetsCollected>=HelmetsToCollect){
			return true;
		}
		return false;
	}

	public void levelComplete(){
		if (levelNumber == 5) {
			SceneManager.LoadScene ("MainMenu");
			music.loadTrack (0);
		} else {
			SceneManager.LoadScene ("Level"+(levelNumber+1));
		}
	}

	public void loadLevel1(){
		SceneManager.LoadScene ("Level1");
		sounds.doClick ();
	}

	public void loadLevel2(){
		sounds.doClick ();
		SceneManager.LoadScene ("Level2");
	}

	public void loadLevel3(){
		sounds.doClick ();
		SceneManager.LoadScene ("Level3");
	}

	public void loadLevel4(){
		sounds.doClick ();
		SceneManager.LoadScene ("Level4");
	}

	public void loadLevel5(){
		sounds.doClick ();
		SceneManager.LoadScene ("Level5");
	}

	public void reload(){
		SceneManager.LoadScene ("Level"+levelNumber);
	}
}
