using UnityEngine;
using System.Collections;

public class winnerboard : MonoBehaviour {

	public GUIText playerOneGUItxt;
	public GUIText playerOneScore;
	public static bool WinnerScreen = false;


	// Use this for initialization
	void Start () {
		WinnerScreen = true;
		playerOneGUItxt.text = GameLogic._playerTurn.PlayerName + " WINS";
		playerOneScore.text = "SCORE: " + GameLogic._playerTurn.PlayerCurrentScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
