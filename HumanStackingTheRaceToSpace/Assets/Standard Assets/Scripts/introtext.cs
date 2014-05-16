using UnityEngine;
using System.Collections;

public class introtext : MonoBehaviour {
	public bool move = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(move == true)
		{
			if (transform.position.x < -15) {
				transform.Translate (Vector3.right * 50 * Time.deltaTime, Space.World);
			}else{move = false;}
		}
	}
}
