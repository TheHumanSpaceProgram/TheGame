using UnityEngine;
using System.Collections;

public class MoveRussianSelection : MonoBehaviour {
	public static bool MoveAway = false;
	public bool col = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ((MoveAway == true) || GameLogic.gameOver) {
			if(col)
			{
				col = false;
				foreach (Transform child in transform)
				{
					if(child.tag.Equals("HumanObject"))
					{
						child.collider2D.enabled = false;
					}

				}
			}

						if (transform.position.x < 60) {
								transform.Translate (Vector3.right * 50 * Time.deltaTime, Space.World);
						}
		} else {
			if(!col)
			{
				col = true;
				foreach (Transform child in transform)
				{
					if(child.tag.Equals("HumanObject"))
					{
						child.collider2D.enabled = true;
					}
				}
			}
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
