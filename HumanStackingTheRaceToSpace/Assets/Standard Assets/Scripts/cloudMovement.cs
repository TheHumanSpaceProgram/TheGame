using UnityEngine;
using System.Collections;

public class cloudMovement : MonoBehaviour {
	public bool intro;
	// Use this for initialization
	void Start () {
	
	}
	float y;
	
	// Update is called once per frame
	void Update () {
		if (GameLogic.GetGameStarted() || intro == true) {
			transform.Translate (Vector3.right * 5 * Time.deltaTime, Space.World);
			if (transform.position.x > 60) {
				y = transform.position.y;
				Vector3 pos = new Vector3(-80, y, 0);
				transform.position = pos;
			}
		}

		}
}
