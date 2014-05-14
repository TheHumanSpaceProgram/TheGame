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
	public GUIText Player1Score;
	public GUIText Player2Score;
	public GUIText guiTimeForEachTurn;
	public GUIText guiTurnCount;
	public AudioClip clip;
	//public AudioSource audioSource;
	string PlayerName { get; set; }


	private static Timer _Timer;
	private static Timer _WaitTimer;

	private static int _MinTimeLimit = 15;
	//private static int _StartTime = 30000;
	private static int _StartTime = 20000;
	private int _TimePrTurn = _StartTime / 1000 ;
	private static int _Time;
	private static int _WaitTimeCounter;

	private int _TurnCount;
	public static int _playerTurnCount;
	private static Player _playerTurn;
	private static List<Player> _playersList;
	private int maxPlayers = 2;
	private static bool gameStarted = false;
	public static bool gameOver = false;
	private static bool timeOutCalled = false;


	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 150;

	private static string TXT_PLAYER_NAME 			= "Player: ";
	private static string TXT_TURNS 				= "Turn: ";
	private static string TXT_TIME_COUNT			= "Time: ";
	private static string TXT_PLAYER_SCORE  		= "Score: ";
	private static string TXT_START_GAME_BUTTON		= "Start Game";
	private static string TXT_END_GAME_BUTTON		= "";
	private static string TXT_ADD_PLAYER_BUTTON		= "Add Player ";



	public static void GameOver(bool actionTaken){
		_Timer.Elapsed -= OnTimedEvent;
		gameOver = true;
		MoveRussianSelection.MoveAway = true;
		MoveAmericanSelection.MoveAway = true;
		_WaitTimer.Stop ();
		if(actionTaken){
			TXT_END_GAME_BUTTON  = _playerTurn.PlayerName + " has lost";
		}
		else{
			if(_playerTurn.PlayerNumber == 0){
				TXT_END_GAME_BUTTON = _playersList[_playersList.Count - 1].PlayerName + " has lost";
			}
			else{
				TXT_END_GAME_BUTTON = _playersList[_playerTurn.PlayerNumber - 1].PlayerName + " has lost";
			}
		}
	}

	private void TimeOut(){
		_Timer.Elapsed -= OnTimedEvent;
		NewObj.TimeOut = true;
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
		_playerTurn = _playersList [0];
		MoveTexts ();
		this._TurnCount = 1;
		_playerTurnCount = 1;
		MoveAmericanSelection.MoveAway = true;
		MoveRussianSelection.MoveAway  = false;
		gameOver = false;
		gameStarted = true;
		TXT_END_GAME_BUTTON = "";

		var water2 = GameObject.Find("water2");
		water2.AddComponent("OceanMovement");
		
		StartTimer ();
	}

	//Starts counting down to when the next turn starts
	public static void ChangePlayer(){
		_Timer.Stop ();

		if(_WaitTimer != null)
		{
			_WaitTimer.Elapsed -= OnTimedEvent;
			_WaitTimer.Stop();
			_WaitTimer.Dispose();
		}
		_WaitTimer = new Timer (6000);
		_WaitTimer.Elapsed += new ElapsedEventHandler (OnWaitTimedEvent);
		_WaitTimer.Interval = 1000;
		_WaitTimer.AutoReset = true;
		_WaitTimeCounter = 0;
		_WaitTimer.Start ();


	}


	//Is called at the start of every turn. Performs setup for the next turn.
	public Player nextPlayer()
	{
		DragMovement.shapePicked = false;
		NewObj.actionTaken = false;
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

		MoveTexts();
		StartTimer ();

		return _playerTurn;
	}

	//Moves the timer depending on whose turn it is
	public void MoveTexts(){
		if(_playerTurn.PlayerNumber == 0){
			Vector3 temp = guiTimeForEachTurn.transform.position;
			temp.x = 0.6f;
			guiTimeForEachTurn.transform.position = temp;
		}
		else{
			Vector3 temp = guiTimeForEachTurn.transform.position;
			temp.x = 0.1f;
			guiTimeForEachTurn.transform.position = temp;
		}
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
		timeOutCalled = false;
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

		GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), 50, groupWidth, groupHeigth));

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
			this.guiPlayerNameText.text 	= TXT_PLAYER_NAME 	+ _playerTurn.PlayerName;
			this.Player1Score.text 			= TXT_PLAYER_SCORE 	+ _playersList[0].PlayerCurrentScore;
			this.Player2Score.text 			= TXT_PLAYER_SCORE 	+ _playersList[1].PlayerCurrentScore;

			this.guiTurnCount.text 			= TXT_TURNS 		+ this._TurnCount;

			if((_TimePrTurn - _Time) == 7 || (_TimePrTurn - _Time) == 5 || (_TimePrTurn - _Time) == 3 || (_TimePrTurn - _Time) == 1)
			{
				this.guiTimeForEachTurn.text	= "";

			}
			else
			{
				this.guiTimeForEachTurn.text	= TXT_TIME_COUNT 	+ (_TimePrTurn - _Time);

			}

			if((_TimePrTurn - _Time) == 5 || (_TimePrTurn - _Time) == 3)
			{
				AudioListener.volume = 0.999999F;			
				AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2), 0.999999999F);
			}
			
			
		}
	}

	public void UpdateGUIClockTXT()
	{
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT + (_TimePrTurn - _Time);	
	}

	// Use this for initialization
	void Start () {
		_playersList = new List<Player>();
		gameOver = false;
		gameStarted = false;
		MoveAmericanSelection.MoveAway = false;
		MoveRussianSelection.MoveAway  = false;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("l")){
			CheckSleeping.SceneSleeping();
		}
	}

	private void Wait(){

	}
	
	//Works in a similar fashion as Update: This function gets called at a fixed interval.
	void FixedUpdate(){
		if(gameStarted){
			if ((_Time == _TimePrTurn) && !timeOutCalled) 
			{
				timeOutCalled = true;
				TimeOut();
			}
			if (_TurnCount < _playerTurnCount) 
			{
				this._TurnCount++; 
				_playerTurn.AddCurrentScore((_TimePrTurn*_TurnCount) - _Time*_TurnCount);

				_playerTurn = nextPlayer();

			}
			if (_Time > _TimePrTurn) 
			{						

				this._TurnCount++;
				_playerTurn = nextPlayer ();
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
		} 
		else {
			MoveAmericanSelection.MoveAway = true;
		}


		
		if(CheckSleeping.sleeping || (_WaitTimeCounter == 10)){
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
