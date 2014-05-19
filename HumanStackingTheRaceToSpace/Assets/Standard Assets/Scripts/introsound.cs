using UnityEngine;
using System.Collections;

public class introsound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter2D(Collider2D theCollider){
		if(theCollider.tag.Equals("HumanObject"))
		{
				theCollider.gameObject.audio.Play();
		}
		if (theCollider.tag.Equals ("Finish")) {
			Application.LoadLevel("mainMenu");		
		}

				
	}
}
