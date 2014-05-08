using UnityEngine;
using System.Collections;

public class MoveRussianSelection : MonoBehaviour {
	public static bool MoveAway = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((MoveAway == true) || GameLogic.gameOver) {
						if (transform.position.x < 60) {
								transform.Translate (Vector3.right * 50 * Time.deltaTime, Space.World);
						}
		} else {
			if (transform.position.x > 28.11935) { 
				transform.Translate (Vector3.left * 50 * Time.deltaTime, Space.World);
			}

		}
	}
	public void away() {
		MoveAway = true;
	}
	public void back(){
		MoveAway = false;
	}


}
