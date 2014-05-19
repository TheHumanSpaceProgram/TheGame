using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	public AudioClip SovietAnthem;
	public AudioClip UsaAnthem;
	public AudioClip buzzer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(GameLogic.buzzer){
			GameLogic.buzzer = false;
			AudioListener.volume = 0.99999F;			
			AudioSource.PlayClipAtPoint(buzzer, new Vector3(5, 1, 2), 0.05F);
		}
		else{
			AudioListener.volume = 0.99999F;
		}
	}

}
