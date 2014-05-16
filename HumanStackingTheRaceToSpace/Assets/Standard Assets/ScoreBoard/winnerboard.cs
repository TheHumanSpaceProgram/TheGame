using UnityEngine;
using System.Collections;

public class winnerboard : MonoBehaviour {

	public GUIText playerOneGUItxt;
	public GUIText playerOneScore;



	// Use this for initialization
	void Start () {
		playerOneGUItxt.text = GameLogic._playerTurn.PlayerName + " WINS";
		playerOneScore.text = "SCORE: " + GameLogic._playerTurn.PlayerCurrentScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
