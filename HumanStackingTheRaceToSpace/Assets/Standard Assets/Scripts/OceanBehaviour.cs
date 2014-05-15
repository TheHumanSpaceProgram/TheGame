using UnityEngine;
using System.Collections;

public class OceanBehaviour : MonoBehaviour {
	bool verbose = false;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	//The game is lost
	public void OnTriggerEnter2D(Collider2D theCollider){
		if(theCollider.tag.Equals("HumanObject")){
			if(verbose){
				print ("Collision enter");
			}
			NewObj theObj = (NewObj)theCollider.GetComponent("NewObj");

			if(!theObj.counted){
				theObj.counted = true;
				theCollider.gameObject.audio.Play();

				GameLogic.GameOver(NewObj.actionTaken);
			}
		}
	}
}