using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckSleeping : MonoBehaviour {
	/*
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 170;
	*/

	public static bool sleeping;
	// Use this for initialization
	void Start () {
		sleeping = SceneSleeping();
	}
	
	// Update is called once per frame
	void Update () {
		sleeping = SceneSleeping();
	}

	public static Rigidbody2D[] AllRigid;

	public static bool SceneSleeping (){

		AllRigid = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];

		foreach (Rigidbody2D Curr in AllRigid) {

			if (!(Curr.IsSleeping()))
			{
				return false;
			}
		}
		return true;
	}

	/*
	void OnGUI () {

		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeigth / 2)), groupWidth, groupHeigth));
		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "sleeping"))
		{
			SceneSleeping();		
		}		
		GUI.EndGroup();
	}
	*/
}
