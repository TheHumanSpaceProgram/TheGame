using UnityEngine;
using System.Collections;

public class SOceanBehaviour : MonoBehaviour {
	bool verbose = false;
	bool shapeNameVerbose = false;


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
			SNewObj theObj = (SNewObj)theCollider.GetComponent("SNewObj");

			if(theObj.commited && !theObj.counted){
				if(verbose){
					print("Valid collision");
				}
				if(shapeNameVerbose){
					print (theCollider.gameObject.name);
				}

				theObj.counted = true;
				theCollider.gameObject.audio.Play();

				//Display the number of points lost
				var temp = (GameObject)Instantiate (theObj.pointPopup, Camera.main.WorldToViewportPoint(theObj.transform.position), Quaternion.identity);
				SPointPopupMovement temp2 = (SPointPopupMovement)temp.GetComponent ("SPointPopupMovement");
				temp2.exists = true;
				//temp2.text = "<b>-" + ((theObj.objectPoints * GameLogic._Time / 2) + 10) + "</b>";
			}
		}
	}
}