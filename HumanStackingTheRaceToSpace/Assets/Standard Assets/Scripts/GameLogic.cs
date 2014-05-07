using UnityEngine;
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



public delegate void OnPlayerChange();

public class GameLogic : MonoBehaviour {

	private bool alphaVersion = true;

	public GUIText guiPlayerNameText;
	public GUIText CurrentPlayerScore;
	public GUIText guiTimeForEachTurn;
	public GUIText guiTurnCount;

	string PlayerName { get; set; }

	private static Timer _Timer;
	private static Timer _WaitTimer;

	private static int _MinTimeLimit = 5;
	private static int _StartTime = 10000;
	private int _TimePrTurn = _StartTime / 1000 ;
	private static int _Time;
	private static int _WaitTimeCounter;

	private int _TurnCount;
	public static int _playerTurnCount;
	private Player _playerTurn;
	private List<Player> _playersList = new List<Player>();
	private int maxPlayers = 2;
	private static bool gameStarted = false;
	private static bool gameOver = false;

	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 150;

	private static string TXT_PLAYER_NAME 			= "Player: ";
	private static string TXT_TURNS 				= "Turn: ";
	private static string TXT_TIME_COUNT			= "Seconds left: ";
	private static string TXT_PLAYER_SCORE  		= "Players Score: ";
	private static string TXT_START_GAME_BUTTON		= "Start Game";
	private static string TXT_END_GAME_BUTTON		= "Game Over";
	private static string TXT_ADD_PLAYER_BUTTON		= "Add Player ";



	public static void GameOver(){
		_Timer.Elapsed -= OnTimedEvent;
		gameOver = true;
	}

	public static bool GetGameStarted(){
		return gameStarted;
	}

	public void StartGame(){
		if(alphaVersion){
			CreatePlayers ();
			CreatePlayers ();
		}
		else{
			CreatePlayers ();
		}
		this._playerTurn = _playersList [0];
		this._TurnCount = 1;
		_playerTurnCount = 1;
		MoveAmericanSelection.MoveAway = true;
		MoveRussianSelection.MoveAway  = false;
		
		gameStarted = true;

		var water2 = GameObject.Find("water2");
		water2.AddComponent("OceanMovement");
		
		StartTimer ();
	}

	public static void ChangePlayer(){
		_Timer.Stop ();		 

		if(_WaitTimer != null)
		{
			_WaitTimer.Elapsed -= OnTimedEvent;
			_WaitTimer.Stop();
			_WaitTimer.Dispose();
		}
		_WaitTimer = new Timer (4000);
		_WaitTimer.Elapsed += new ElapsedEventHandler (OnWaitTimedEvent);
		_WaitTimer.Interval = 1000;
		_WaitTimer.AutoReset = true;
		_WaitTimeCounter = 0;
		_WaitTimer.Start ();


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
		if (_TimePrTurn > _MinTimeLimit) 
		{
			_TimePrTurn--;
		}

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


	public void StartGameButtons()
	{
		var water2 = GameObject.Find("water2");
		Destroy(water2.GetComponent("OceanMovement"));

		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), (30), groupWidth, groupHeigth));

		/* FOR MULTIPLAYER MORE THAN 2 PLAYERS
		 */
		if(!alphaVersion){
			if(maxPlayers > (_playersList.Count + 1)){
				if (GUI.Button (new Rect (0, 60, buttonWidth, buttonHeight), TXT_ADD_PLAYER_BUTTON + (_playersList.Count + 2))) 
				{
					CreatePlayers ();
				}
			}
		}


		if (GUI.Button (new Rect (0, 0, buttonWidth, buttonHeight), TXT_START_GAME_BUTTON)) {
			StartGame ();				
		}		

		GUI.EndGroup ();

	}

	public void EndGameButtons(){
		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), (30), groupWidth, groupHeigth));
		if (GUI.Button (new Rect (0, 60, buttonWidth, buttonHeight), TXT_END_GAME_BUTTON)) {

			Application.LoadLevel("mainMenu");
			
		}
		GUI.EndGroup ();
	}

	
	void OnGUI () {
		if (!gameStarted) 
		{
			StartGameButtons ();
		}
		if(gameOver){
			_Timer.Stop();
			EndGameButtons ();
		}
	}

	public void UpdateGuiTXT()
	{
		if(gameStarted){
			this.guiPlayerNameText.text 	= TXT_PLAYER_NAME 	+ this._playerTurn.PlayerName;
			this.CurrentPlayerScore.text 	= TXT_PLAYER_SCORE 	+ this._playerTurn.PlayerCurrentScore;
			this.guiTimeForEachTurn.text	= TXT_TIME_COUNT 	+ (_TimePrTurn - _Time);
			this.guiTurnCount.text 			= TXT_TURNS 		+ this._TurnCount;
		}
	}

	public void UpdateGUIClockTXT()
	{
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT + (_TimePrTurn - _Time);	
	}

	// Use this for initialization
	void Start () {
		gameOver = false;
		gameStarted = false;
	}

	// Update is called once per frame
	void Update () {
		

	}

	private void Wait(){

	}
	
	void FixedUpdate(){
		if(gameStarted){
			if (_Time == _TimePrTurn) 
			{
				GameOver();
			}
			if (_TurnCount < _playerTurnCount) 
			{
				this._TurnCount++; 
				this._playerTurn.AddCurrentScore((_TimePrTurn*_TurnCount) - _Time*_TurnCount);

				this._playerTurn = nextPlayer();

			}
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
	}
	

	private static void OnTimedEvent(object source, ElapsedEventArgs e)
	{
		_Time++;				
	}

	private static void OnWaitTimedEvent(object source, ElapsedEventArgs e)
	{
		_WaitTimeCounter++;


		if (_playerTurnCount % 2 != 0) {
						MoveRussianSelection.MoveAway = true;
				} else {
						MoveAmericanSelection.MoveAway = true;
				}



		if (_WaitTimeCounter == 4) {
			_WaitTimeCounter = 0;		
			_playerTurnCount++;
			if (_playerTurnCount % 2 != 0) {
				MoveRussianSelection.MoveAway = false;
			} else {
				MoveAmericanSelection.MoveAway = false;
			}

			_WaitTimer.Elapsed -= OnWaitTimedEvent;
			_WaitTimer.Stop();
			_WaitTimer.Dispose();
			_WaitTimer = null;

		}
	}
}
