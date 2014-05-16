using UnityEngine;
using System.Collections;

public class SNewObj : MonoBehaviour {

	private bool verbose = false;
	
	//Note to self: DON'T make these two variables static!
	private bool created = false;
	private bool commited = false;
	
	public static bool actionTaken = false;
	
	public GameObject theObj;
	public GameObject instance;
	public static GameObject selectedShape;
	public MoveRussianSelection russianSelect;
	private PolygonCollider2D polyC;
	
	//Variables for the rigidbody
	public int mass;
	public int gravityScale;
	public PhysicsMaterial2D myMat;
	
	public static bool TimeOut = false;
	
	public int objectPoints = 10;
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

			}
			if((Input.GetKey("e") || Input.GetKey("mouse 2"))){
				
				MoveSelectionOnScreen();
				Destroy(instance);
				//MoveSelectionOnScreen();
			}
				
		}
	}
	
	
	void OnMouseDown () {
		if (created == false) {
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
		Destroy (instance.GetComponent("SDragMove"));
		instance.rigidbody2D.mass = mass;
		instance.rigidbody2D.gravityScale = gravityScale;
		instance.rigidbody2D.isKinematic = false;
		instance.collider2D.sharedMaterial = myMat;
		instance.collider2D.enabled = false;
		instance.collider2D.enabled = true;
		MoveSelectionOnScreen ();
		
	}
	

	void MoveSelectionAway (){
		
		MoveRussianSelection.MoveAway = true;
		
	}
	void MoveSelectionOnScreen (){
			MoveRussianSelection.MoveAway = false;

	}
}

