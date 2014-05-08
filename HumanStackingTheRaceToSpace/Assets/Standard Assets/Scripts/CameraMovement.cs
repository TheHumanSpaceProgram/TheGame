﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	private bool verbose = false;
	private float movementSpeed = 0.5f;
	private float maxUp = 290f;
	private float maxDown = 120f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GameLogic.GetGameStarted()){
			if(Input.GetKey("up") || Input.GetKey ("w")){
				this.transform.Translate(Vector3.up * movementSpeed);
			}
			if(Input.GetKey("down") || Input.GetKey ("s")){
				this.transform.Translate(Vector3.up * -1 * movementSpeed);
			}

			if(transform.position.y > maxUp){
				Vector3 tempVector = new Vector3(transform.position.x, maxUp, transform.position.z);
				transform.position = tempVector;
				if(verbose){
					print ("Reached the top");
				}
			}
			if(this.transform.position.y < maxDown){
				Vector3 tempVector = new Vector3(transform.position.x, maxDown, transform.position.z);
				transform.position = tempVector;
				if(verbose){
					print ("Hit the bottom");
				}
			}
		}
	}
}