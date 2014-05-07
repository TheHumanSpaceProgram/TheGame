using UnityEngine;
using System.Collections;

public class NewObj : MonoBehaviour {
	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private bool created = false;
	private bool commited = true;
	private int groupWidth = 200;
	private int groupHeigth = 170;
	public GameObject theObj;
	public GameObject instance;
	public MoveRussianSelection russianSelect;
	public MoveAmericanSelection americanSelect;
	private PolygonCollider2D polyC;
	
	public static bool TimeOut = false;
	// Use this for initialization
	void Start () {
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (commited == false && created == true) {
			if (Input.GetKey("a")){
				gameObject.transform.Rotate(Vector3.forward * Time.deltaTime * 75, Space.World);
			}
			if (Input.GetKey("d")){
				gameObject.transform.Rotate(Vector3.back * Time.deltaTime * 75, Space.World);
			}
			if(Input.GetKey("space") && (!Input.GetKey("mouse 0"))){
				
				commited = true;
				GiveRigid();
				GameLogic.ChangePlayer();
				//MoveSelectionOnScreen();
			}
			if(Input.GetKey("e")){
				
				MoveSelectionOnScreen();
				Destroy(instance);
				//MoveSelectionOnScreen();
			}
			/*if(TimeOut)
			{
				TimeOut = false;
				commited = true;
				GiveRigid ();
				GameLogic.ChangePlayer();
			}*/
		}
	}
	
	
	void OnMouseDown () {
		
		if (created == false && GameLogic.GetGameStarted()) {
			GameObject instance = (GameObject)Instantiate(theObj, transform.position, transform.rotation);
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
		Destroy (instance.GetComponent("DragMovement"));
		instance.rigidbody2D.mass = 200;
		instance.rigidbody2D.gravityScale = 1;
		instance.rigidbody2D.isKinematic = false;
		
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
