using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

	public string PlayerName { get; set; }
	public int PlayerNumber { get; set; }
	public int PlayerCurrentScore { get; set; }
	public int PlayerTotalScore { get; set; }

	public int AddCurrentScore(int score)
	{
		PlayerCurrentScore += score;
		return PlayerCurrentScore;
	}

	public int AddTotalScore(int score)
	{
		PlayerTotalScore += score;
		return PlayerTotalScore;

	}
}


public class GameLogic : MonoBehaviour {

	public GUIText _guiText;
	string PlayerName { get; set; }
	private Player _playerTurn;
	private List<Player> _playersList = new List<Player>();

	public void AddPlayer(Player player)
	{
		_playersList.Add (player);
	}

	public Player nextPlayer()
	{
		int playersCount = _playersList.Count;
		int currentPlayer = _playerTurn.PlayerNumber;

		if (currentPlayer == (playersCount - 1)) 
		{
				_playerTurn = _playersList [0];
		} 
		else 
		{
			_playerTurn = _playersList[_playerTurn.PlayerNumber + 1];
		}

		return _playerTurn;
	}

	public List<Player> CreatePlayers(){

		_playersList.Clear ();

		Player player1 = new Player ();
		Player player2 = new Player ();

		player1.PlayerName = "Player1";
		player1.PlayerNumber = 0;

		player2.PlayerName = "Player2";
		player2.PlayerNumber = 1;
				
		_playersList.Add (player1);
		_playersList.Add (player2);

		return _playersList;
	}


	void OnGui(){


		_guiText.text = "Player: " + _playerTurn.PlayerName;
		_guiText.color = Color.blue;
	}

	// Use this for initialization
	void Start () {
		this._guiText.text = "sdf";
		this.CreatePlayers ();
	}

	// Update is called once per frame
	void Update () {

	}
}
