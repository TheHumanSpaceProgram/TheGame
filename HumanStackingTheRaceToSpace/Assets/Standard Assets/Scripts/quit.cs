using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("escape")) {
			if(GameLogic._Timer != null){
			GameLogic._Timer.Stop ();
			}
			if(GameLogic._WaitTimer != null){
				GameLogic._WaitTimer.Stop ();
			}
			Application.LoadLevel("mainMenu");
		}

		if (Input.GetKeyDown("p")){
			if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}
			else
			{
				Time.timeScale = 0;
			}

		}
	}
}
