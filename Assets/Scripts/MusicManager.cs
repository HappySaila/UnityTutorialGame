using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip Theme;
	public AudioClip[] LevelTracks;
	public AudioClip GameOver;

	AudioClip nextTrack;
	AudioSource player;

	public float fadeTime;


	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);

		if (GameObject.Find ("MusicManager")){
			if (!GameObject.Find ("MusicManager").Equals (this.gameObject)){
				Destroy (gameObject);
			}
		}
		player = GetComponent <AudioSource> ();
		loadTrack (0);
	}

	public void loadTrack(int i){
		if (i==0){
			//load theme song
			nextTrack = Theme;
		} else if (i==1){
			//load die
			nextTrack = GameOver;
		}

		//transition from the current playing track to next track
		StartCoroutine (TransitionSound ());
	}

	IEnumerator TransitionSound(){
		//fade track out
		while (player.volume > 0.01){
			player.volume = Mathf.Lerp (player.volume, 0, Time.deltaTime * fadeTime);
			yield return new WaitForSeconds (0.1f);
		}

		//put new track on
		player.Stop ();
		player.clip = nextTrack;
		player.Play ();

		//fade track in
		while (player.volume < 0.99){
			player.volume = Mathf.Lerp (player.volume, 1, Time.deltaTime * fadeTime);
			yield return new WaitForSeconds (0.1f);
		}

		player.volume = 1;
		yield return null;
	}

	void Update(){
	}

	public void Play(){
		if (!player.isPlaying){
			player.clip = LevelTracks [Random.Range (0, LevelTracks.Length)];
			player.Play ();
		}
	}
}
