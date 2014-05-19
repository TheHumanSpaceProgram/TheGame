using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {
	public bool intro;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("escape")) {
			Application.LoadLevel("mainMenu");
		}

		if (Input.GetKeyDown("p") && !intro){
			if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
				if(GameLogic._Timer != null){
					GameLogic._Timer.Start();
				}
				if(GameLogic._WaitTimer != null){
					GameLogic._WaitTimer.Start();
				}
			}
			else
			{
				Time.timeScale = 0;
				if(GameLogic._Timer != null){
					GameLogic._Timer.Stop();
				}
				if(GameLogic._WaitTimer != null){
					GameLogic._WaitTimer.Stop();
				}
			}

		}
	}
}
