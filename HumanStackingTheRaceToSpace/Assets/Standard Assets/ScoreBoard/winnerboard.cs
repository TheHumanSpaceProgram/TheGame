using UnityEngine;
using System.Collections;

public class winnerboard : MonoBehaviour {

	public GUIText playerOneGUItxt;
	public GUIText playerOneScore;
	public static bool WinnerScreen = false;
	public AudioClip sovietAnthem;
	public AudioClip USAAnthem;


	// Use this for initialization
	void Start () {
		if (GameLogic._playerTurn.PlayerName == "The USA") {
			AudioSource.PlayClipAtPoint(USAAnthem, transform.position);
				} else {
			AudioSource.PlayClipAtPoint(sovietAnthem, transform.position);
		}

		WinnerScreen = true;
		playerOneGUItxt.text = GameLogic._playerTurn.PlayerName + " WINS";
		playerOneScore.text = "SCORE: " + GameLogic._playerTurn.PlayerCurrentScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
