using UnityEngine;
using System.Collections;

public class OceanMovement : MonoBehaviour {

	float savedTime;
	// Use this for initialization
	void Start () {
		savedTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		/*float savedTime = Time.time;

		if (Time.time - savedTime >= 1) {
						transform.Translate (Vector3.up * Time.deltaTime, Space.World);
				} 
		else {
			transform.Translate (Vector3.down * Time.deltaTime, Space.World);
			                     }*/
		if(Time.time - savedTime <= 4)
		{
			transform.Translate(Vector3.up * Time.deltaTime, Space.World);
		}
		else if (Time.time - savedTime >= 4 && Time.time - savedTime  <= 8)
		{
			transform.Translate(Vector3.down * Time.deltaTime, Space.World);
		}
		else if (Time.time - savedTime > 8)
		{
			savedTime = Time.time;
		}
	}
}
