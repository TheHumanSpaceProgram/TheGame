﻿using UnityEngine;
using System.Collections;

public class quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("q")) {
			Application.LoadLevel("mainMenu");
		}

	}
}
