using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("escape")) {
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

		if(Input.GetKeyDown ("y")){
			GameObject temp = ShapeFactory.GetShape(1);
			temp.transform.position = new Vector3(0, 150, 0);
		}

	}
}
