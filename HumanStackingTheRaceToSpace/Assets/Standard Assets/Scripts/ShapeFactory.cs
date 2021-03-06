﻿using UnityEngine;
using System.Collections;

public class ShapeFactory : MonoBehaviour {
	public static bool verbose = false;
	public static GameObject[][] ShapeLists;
	public static System.Random RandomGenerator;
	private static int NumberOfShapes;

	public void Start(){
		RandomGenerator = new System.Random();
		NumberOfShapes = 6;
		ShapeLists = new GameObject[2][];
		ShapeLists[0] = new GameObject[NumberOfShapes];
		ShapeLists[1] = new GameObject[NumberOfShapes];
		
		//Assigning the shapes here because the class is static
		ShapeLists[0][0] = GameObject.Find ("Proto1Circle");
		ShapeLists[0][1] = GameObject.Find ("Proto1Pentagon");
		ShapeLists[0][2] = GameObject.Find ("Proto1Rectangle");
		ShapeLists[0][3] = GameObject.Find ("Proto1Triangle");
		ShapeLists[0][4] = GameObject.Find ("Proto1Bomb");
		ShapeLists[0][5] = GameObject.Find ("Proto1HalfCircle");

		ShapeLists[1][0] = GameObject.Find ("Proto2Circle");
		ShapeLists[1][1] = GameObject.Find ("Proto2Pentagon");
		ShapeLists[1][2] = GameObject.Find ("Proto2Rectangle");
		ShapeLists[1][3] = GameObject.Find ("Proto2Triangle");
		ShapeLists[1][4] = GameObject.Find ("Proto2Bomb");
		ShapeLists[1][5] = GameObject.Find ("Proto2HalfCircle");
	}

	//Returns a random shape from the ShapeLists
	public static GameObject GetShape(int PlayerNumber){
		//GameObject instance = (GameObject)Instantiate(theObj, transform.position, transform.rotation);
		int index = RandomGenerator.Next() % NumberOfShapes;
		GameObject returnValue = (GameObject)Instantiate(ShapeLists[PlayerNumber][index]);
		if(verbose){
			print (index);
		}
		return returnValue;
	}
}
