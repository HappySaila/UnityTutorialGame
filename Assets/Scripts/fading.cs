using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fading : MonoBehaviour {

	public float fadeSpeed;
	public bool canFadeOut;
	public levelManager LevelManager;

	Image sheet;
	Color32 target;

	// Use this for initialization
	void Start () {
		target = new Color32 (0,0,0,255);
		sheet = GetComponent <Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canFadeOut){
			sheet.color = Color.Lerp (sheet.color, target, Time.deltaTime * fadeSpeed);
			print (sheet.color.a*255);
			if (sheet.color.a*255 > 254){
				LevelManager.levelComplete ();
			}
		}
	}
}
