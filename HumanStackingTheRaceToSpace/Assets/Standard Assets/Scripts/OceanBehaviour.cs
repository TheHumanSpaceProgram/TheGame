using UnityEngine;
using System.Collections;

public class OceanBehaviour : MonoBehaviour {
	bool verbose = false;
	public GUIText gameOver;


	// Use this for initialization
	void Start () {
		this.gameOver.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	//The game is lost
	public void OnTriggerEnter2D(Collider2D theCollider){
		if(theCollider.tag.Equals("HumanObject")){
			if(verbose){
				print ("Collision enter");
			}
			
			this.gameOver.text = "<b>Game Over</b>";
			theCollider.gameObject.audio.Play();

			GameLogic.GameOver();
		}
	}
}