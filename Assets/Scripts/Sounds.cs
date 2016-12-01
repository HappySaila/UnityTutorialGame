using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class Sounds : MonoBehaviour {

	public AudioClip jump;
	public AudioClip doubleJump;
	public AudioClip hurt;
	public AudioClip rocketFire;
	public AudioClip rocketAir;
	public AudioClip rocketHit;
	public AudioClip die;
	public AudioClip takeOff;
	public AudioClip crash;
	public AudioClip defaultShoot;
	public AudioClip machineGunShoot;
	public AudioClip buttonClick;
	public AudioClip machineGunDie;
	public AudioClip boarGrunt;
	public AudioClip plantSpit;
	public AudioClip plantBounce;
	public AudioClip GetHealth;
	public AudioClip GetAmmo;

	public AudioClip footStep1;
	public AudioClip footStep2;
	public AudioClip currentFootStep;


	public bool playerOn;

	public AudioSource player;

	public float soundVolume;

	MusicManager music;




	// Use this for initialization
	void Start () {
		player = GetComponent <AudioSource> ();
		currentFootStep = footStep1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void doJump(){
		player.PlayOneShot (jump, soundVolume);
	}

	public void doDoubleJump(){
		player.PlayOneShot (doubleJump, soundVolume);
	}

	public void doHurt(){
		player.PlayOneShot (hurt, soundVolume);
	}

	public void doRocketfire(){
		player.PlayOneShot (rocketFire, soundVolume);
	}

	public void doRocketAir(){
		player.PlayOneShot (rocketAir, soundVolume);
	}

	public void doRocketHit(){
		player.PlayOneShot (rocketHit, soundVolume);
	}

	public void doDie(){
		player.PlayOneShot (die, soundVolume);
	}

	public void doGetHealth(){
		player.PlayOneShot (GetHealth, soundVolume);
	}

	public void doGetAmmo(){
		player.PlayOneShot (GetAmmo, soundVolume);
	}

	public void doRocketCrash(){
		player.PlayOneShot (crash, soundVolume);
		if (GameObject.Find ("MusicManager")){
			music = GameObject.Find ("MusicManager").GetComponent <MusicManager>();
			music.Play ();
		}
	}

	public void doFootStep(){
		player.PlayOneShot (currentFootStep, soundVolume);

		if (currentFootStep == footStep1){
			currentFootStep = footStep2;
		} else{
			currentFootStep = footStep1;
		}
	}

	public void doDefaultShoot(){
		player.PlayOneShot (defaultShoot, soundVolume);
	}

	public void doBoarGrunt(){
		player.PlayOneShot (boarGrunt, soundVolume);
	}

	public void doCannonFire(){
		player.PlayOneShot (machineGunShoot, soundVolume/4);
	}

	public void doPlantSpit(){
		player.PlayOneShot (plantSpit, soundVolume);
	}

	public void doBounceSound(AudioClip bounceSound){
		player.PlayOneShot (bounceSound, soundVolume);
	}

	public void doDieSound(AudioClip dieSound){
		player.PlayOneShot (dieSound, soundVolume);
	}

	public void doClick(){
		player.PlayOneShot (buttonClick);
	}

	public void doTakeOff(){
		player.PlayOneShot (takeOff, soundVolume);
		StartCoroutine (fadeSound ());
	}

	IEnumerator fadeSound(){
		yield return new WaitForSeconds (1f);
		while(player.volume > 0.2f){
			player.volume -= Time.deltaTime / 1f;
			yield return new WaitForSeconds(0.1f);
		}

		//volume is below 0.1
		player.Stop ();
		player.volume = 1;
	}
}
