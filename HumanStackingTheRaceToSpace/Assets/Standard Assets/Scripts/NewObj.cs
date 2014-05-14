using UnityEngine;
using System.Collections;

public class NewObj : MonoBehaviour {
	/*
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeigth = 170;
	*/
	private bool verbose = false;

	//Note to self: DON'T make these two variables static!
	private bool created = false;
	private bool commited = false;

	public static bool actionTaken = false;

	public GameObject theObj;
	public GameObject instance;
	public static GameObject selectedShape;
	public MoveRussianSelection russianSelect;
	public MoveAmericanSelection americanSelect;
	private PolygonCollider2D polyC;

	//Variables for the rigidbody
	public int mass;
	public int gravityScale;
	public PhysicsMaterial2D myMat;
	
	public static bool TimeOut = false;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (commited == false && created == true) {
			gameObject.transform.Rotate(Vector3.back * Input.GetAxis("Mouse ScrollWheel") * 75, Space.World);
			if (Input.GetKey("a")){
				gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * 75, Space.World);
			}
			if (Input.GetKey("d")){
				gameObject.transform.Rotate(Vector3.back * Time.deltaTime * 75, Space.World);
			}
			if((Input.GetKey("mouse 1") || Input.GetKey("space")) && (!Input.GetKey("mouse 0"))){
				if(verbose){
					print (this.gameObject);
					print ("Commiting");
				}
				commited = true;
				GiveRigid();
				ReplaceSelectionShape();
				GameLogic.ChangePlayer();
				//MoveSelectionOnScreen();
			}
			if((Input.GetKey("e") || Input.GetKey("mouse 2"))){
				
				MoveSelectionOnScreen();
				Destroy(instance);
				//MoveSelectionOnScreen();
			}

			if(TimeOut)
			{
				if(verbose){
					print (this.gameObject);
				}
				if(DragMovement.shapePicked){
					if(verbose){
						print ("ShapePicked");
					}
					TimeOut = false;
					commited = true;
					//gameObject.AddComponent("Rigidbody2D");
					gameObject.AddComponent("PolygonCollider2D");
					GiveRigid ();
					ReplaceSelectionShape();
					GameLogic.ChangePlayer();
				}
				else{
					if(verbose){
						print("else");
					}
					GameLogic.GameOver(commited);
				}
			}
		}
		
	}
	
	
	void OnMouseDown () {
		if (created == false && GameLogic.GetGameStarted()) {
			GameObject instance = (GameObject)Instantiate(theObj, transform.position, transform.rotation);
			selectedShape = instance;
			instance.transform.parent = gameObject.transform.parent;
			instance.transform.localScale = transform.localScale;
			transform.parent = null;
			created = true;
			commited = false;
			MoveSelectionAway();
			polyC = (PolygonCollider2D)instance.GetComponent("PolygonCollider2D");
			polyC.enabled = true;
		}
	}
	
	void GiveRigid (){
		actionTaken = true;
		Destroy (instance.GetComponent("DragMovement"));
		instance.rigidbody2D.mass = mass;
		instance.rigidbody2D.gravityScale = gravityScale;
		instance.rigidbody2D.isKinematic = false;
		instance.collider2D.sharedMaterial = myMat;
		instance.collider2D.enabled = false;
		instance.collider2D.enabled = true;
		
	}

	//Give the user a new random shape
	void ReplaceSelectionShape(){
		GameObject tempShape = ShapeFactory.GetShape((GameLogic._playerTurnCount + 1) % 2);
		tempShape.transform.parent = selectedShape.transform.parent;
		tempShape.transform.position = selectedShape.transform.position;
		//Destroy(selectedShape.gameObject);
		selectedShape.SetActive(false);
	}
	
	void OnGUI () {
		/*if (commited == false) {
			GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeigth / 2)), groupWidth, groupHeigth));
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "Commit"))
			{
				GiveRigid();
				
				commited = true;
				GameLogic.ChangePlayer();

				
			}
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "change shape"))
			{


				MoveSelectionOnScreen();
				Destroy(instance);

			}
			GUI.EndGroup();


		}*/
	}
	
	void MoveSelectionAway (){
		
		MoveRussianSelection.MoveAway = true;
		MoveAmericanSelection.MoveAway = true;
		
	}
	void MoveSelectionOnScreen (){
		if(GameLogic._playerTurnCount % 2 != 0)
		{
			MoveRussianSelection.MoveAway = false;
			
		}
		else
		{
			MoveAmericanSelection.MoveAway = false;
		}
	}
}
