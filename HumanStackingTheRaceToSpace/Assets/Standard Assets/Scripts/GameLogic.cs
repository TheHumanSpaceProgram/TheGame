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

	public GUIText guiPlayerNameText;
	public GUIText CurrentPlayerScore;
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


	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 50;
	
	void OnGUI () {

		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), (30), groupWidth, groupHeigth));
		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "Next Player"))
		{
			Player next = this.nextPlayer ();
			this.guiPlayerNameText.text = "Player Turn: " + _playerTurn.PlayerName;
			this.CurrentPlayerScore.text = "Player Score: " + _playerTurn.PlayerCurrentScore;
		}

		GUI.EndGroup();
	
	}

	// Use this for initialization
	void Start () {
		this.CreatePlayers ();
		this._playerTurn = _playersList [0];

		this.guiPlayerNameText.text = "Player Turn: " + _playerTurn.PlayerName;
		this.CurrentPlayerScore.text = "Player Score: " + _playerTurn.PlayerCurrentScore;
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){

		//Player next = this.nextPlayer ();
		//this.guiPlayerNameText.text = "Player Turn: " + _playerTurn.PlayerName;
		//this.CurrentPlayerScore.text = "Player Score: " + _playerTurn.PlayerCurrentScore;
	}

	int count = 0;
	void OnMouseDown() {

		count++;
		this.CurrentPlayerScore.text = "Player Score: " + count;
	}


}
