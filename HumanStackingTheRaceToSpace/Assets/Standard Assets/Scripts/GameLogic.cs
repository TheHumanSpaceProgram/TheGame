using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Timers;


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
	public GUIText guiTimeForEachTurn;
	public GUIText guiTurnCount;

	string PlayerName { get; set; }

	private Timer _Timer;

	private static int _StartTime = 10000;
	private int _TimePrTurn = 10 ;

	private static int _Time;
	private int _TurnCount;
	private Player _playerTurn;
	private List<Player> _playersList = new List<Player>();

	private static string TXT_PLAYER_NAME 			= "Player: ";
	private static string TXT_TURNS 				= "Turn: ";
	private static string TXT_TIME_COUNT			= "Seconds left: ";
	private static string TXT_PLAYER_SCORE  		= "Players Score: ";
	private static string TXT_START_GAME_BUTTON		= "Start Game";

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
		// Hook up the Elapsed event for the timer.
		_Timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

		_Timer.Interval = 1000;
		_Timer.AutoReset = true;
		_Timer.Enabled = true;
		_Timer.Start ();
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
		if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), TXT_START_GAME_BUTTON))
		{

			this.CreatePlayers ();


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
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT 	+ _Time;
		this.guiTurnCount.text 			= TXT_TURNS 		+ this._TurnCount;
	}

	public void UpdateGUIClockTXT()
	{
		this.guiTimeForEachTurn.text	= TXT_TIME_COUNT 	+ _Time;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		

	}

	void FixedUpdate(){

		if (_Time > _TimePrTurn) 
		{
			
			_Time = 0;
			
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
