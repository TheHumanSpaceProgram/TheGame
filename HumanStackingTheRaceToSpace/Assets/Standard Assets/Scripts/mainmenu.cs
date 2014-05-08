using UnityEngine;
using System.Collections;

public class mainmenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 170;

	void OnGUI () {
		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeigth / 2)), groupWidth, groupHeigth));
		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "Start The Stacking"))
		{
			Application.LoadLevel("humanStacking");
		}		
		if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight), "How To Play"))
		{
			Application.LoadLevel("tutorial");
		}
		if(GUI.Button(new Rect(0,120,buttonWidth,buttonHeight), "Quit"))
		{
			Application.Quit();
		}
		GUI.EndGroup();
	}

	// Update is called once per frame
	void Update () {
	
	}
}
