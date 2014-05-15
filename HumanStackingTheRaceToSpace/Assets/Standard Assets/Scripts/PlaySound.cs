using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {
	private bool playing = false;
	public AudioClip SovietAnthem;
	public AudioClip UsaAnthem;
	public AudioClip buzzer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameLogic.gameOver == true && !(playing)) {
			playing = true;
			if((GameLogic._playerTurnCount % 2) == 0)
			{
				AudioListener.volume = 0.999999F;			
				AudioSource.PlayClipAtPoint(SovietAnthem, new Vector3(5, 1, 2), 0.999999999F);
				//print ("soviet win");
				//audio.PlayOneShot(UsaAnthem);
			}
			else 
			{
				AudioListener.volume = 0.999999F;			
				AudioSource.PlayClipAtPoint(UsaAnthem, new Vector3(5, 1, 2), 0.999999999F);
				//print("usa win");
				//audio.PlayOneShot(SovietAnthem);
			}

		}
		if(GameLogic.buzzer){
			AudioListener.volume = 0.999999F;			
			AudioSource.PlayClipAtPoint(buzzer, new Vector3(5, 1, 2), 0.999999999F);
		}
	}

}
