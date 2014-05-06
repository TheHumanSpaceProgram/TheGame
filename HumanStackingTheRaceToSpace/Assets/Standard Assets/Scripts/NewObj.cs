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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown () {
		if (created == false) {
			GameObject instance = (GameObject)Instantiate(theObj, transform.position, transform.rotation);
			created = true;
			commited = false;
		}
		
	}
	void GiveRigid (){
		Destroy (instance.GetComponent("DragMovement"));
		instance.rigidbody2D.mass = 200;
		instance.rigidbody2D.gravityScale = 1;
		instance.rigidbody2D.isKinematic = false;
	}

	void OnGUI () {
		if (commited == false) {
			GUI.BeginGroup (new Rect (((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeigth / 2)), groupWidth, groupHeigth));
			if(GUI.Button(new Rect(0,0,buttonWidth,buttonHeight), "Commit"))
			{
				GiveRigid();
				commited = true;
			}
			GUI.EndGroup();
		}

	}
}
