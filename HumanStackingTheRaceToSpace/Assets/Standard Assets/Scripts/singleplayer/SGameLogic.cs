using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;


public class SGameLogic : MonoBehaviour {

	
	//public AudioSource audioSource;
	string PlayerName { get; set; }




	public void StartGame(){

		MoveRussianSelection.MoveAway  = false;
		var water2 = GameObject.Find("water2");
		water2.AddComponent("OceanMovement");

	}
	
	

	// Use this for initialization
	void Start () {
		var water2 = GameObject.Find("water2");
		Destroy(water2.GetComponent("OceanMovement"));
		StartGame ();
		MoveRussianSelection.MoveAway  = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
