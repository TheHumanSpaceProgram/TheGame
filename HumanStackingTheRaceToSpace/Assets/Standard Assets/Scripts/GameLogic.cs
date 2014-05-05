using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Timers;


public class Player {

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
	public GUIText guiTimeForEachTurn;
	public GUIText guiTurnCount;

	string PlayerName { get; set; }

	private Timer _Timer;

	private static int _StartTime = 5000;
	private int _TimePrTurn = _StartTime / 1000 ;
	private static int _Time;

	private int _PlayersCount;
	private int _TurnCount;
	private Player _playerTurn;
	private List<Player> _playersList = new List<Player>();

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 150;

	private static string TXT_PLAYER_NAME 			= "Player: ";
	private static string TXT_TURNS 				= "Turn: ";
	private static string TXT_TIME_COUNT			= "Seconds left: ";
	private static string TXT_PLAYER_SCORE  		= "Players Score: ";
	private static string TXT_START_GAME_BUTTON		= "Start Game";
	private static string TXT_ADD_PLAYER_BUTTON		= "Add Player ";





	public static void GameOver(){

		EditorUtility.DisplayDialog ("Game Over" , "Game Over" , "OK");
		Application.LoadLevel("mainMenu");

	}

	public void AddPlayer(Player player)
	{
		_playersList.Add (player);
		_playerTurn = player;
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

		StartTimer ();

		return _playerTurn;
	}
	
	public void StartTimer()
	{
		if(_Timer != null)
		{
			_Timer.Elapsed -= OnTimedEvent;
			_Timer.Stop();
			_Timer.Dispose();
		}
		_Timer = new Timer (_StartTime);
		_Time = 0;
		// Hook up the Elapsed event for the timer.
		_Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

		_Timer.Interval = 1000;
		_Timer.AutoReset = true;
		_Timer.Enabled = true;
		_Timer.Start ();
	}
	
	public List<Player> CreatePlayers(){

		Player newPlayer = new Player();
		newPlayer.PlayerName = "Player " + (_playersList.Count + 1);
		newPlayer.PlayerNumber = _playersList.Count;
		_playersList.Add(newPlayer);

		return _playersList;
	}



	
	void OnGUI () {
	
		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), (30), groupWidth, groupHeigth));
		if(GUI.Button(new Rect(0,60,buttonWidth,buttonHeight), TXT_ADD_PLAYER_BUTTON + (_PlayersCount + 1)))
		{
			_PlayersCount++;
			CreatePlayers();
		}

		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), TXT_START_GAME_BUTTON))
		{
			this._playerTurn = _playersList [0];
			this._TurnCount = 1;
			StartTimer();
			UpdateGuiTXT();
			
		}


		GUI.EndGroup();
	
	}

	public void UpdateGuiTXT()
	{
		this.guiPlayerNameText.text 	= TXT_PLAYER_NAME 	+ this._playerTurn.PlayerName;
		this.CurrentPlayerScore.text 	= TXT_PLAYER_SCORE 	+ this._playerTurn.PlayerCurrentScore;
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT 	+ (_TimePrTurn - _Time);
		this.guiTurnCount.text 			= TXT_TURNS 		+ this._TurnCount;
	}

	public void UpdateGUIClockTXT()
	{
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT + (_TimePrTurn - _Time);	
	}

	// Use this for initialization
	void Start () {
		_PlayersCount = 1;
		CreatePlayers ();
		this._playerTurn = _playersList [0];
	}

	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate(){

		if (_Time > _TimePrTurn) 
		{						
			this._TurnCount++;
			this._playerTurn = nextPlayer ();
		} 
		else 
		{
			UpdateGuiTXT();
		}



	}
	

	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{

		_Time++;
	}
	
}
