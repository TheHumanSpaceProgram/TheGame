using UnityEngine;
using System.Collections;

public class RestartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 320;
	
	void OnGUI () {
		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeigth / 2)), groupWidth, groupHeigth));
		if(GUI.Button(new Rect(0,260,buttonWidth,buttonHeight), "Rematch"))
		{
			Application.LoadLevel("humanStacking");
		}
		GUI.EndGroup();
	}
}
