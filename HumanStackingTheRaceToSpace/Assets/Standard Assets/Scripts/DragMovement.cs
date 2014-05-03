using UnityEngine;
using System.Collections;

public class DragMovement : MonoBehaviour {
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private float gravityScale;
	
	// Use this for initialization
	void Start () {
		gravityScale = rigidbody2D.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Setup for moving the shape
	void OnMouseDown(){
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		
		//Makes the shape stop moving, rotating and colliding with other things
		Destroy(gameObject.GetComponent ("Rigidbody2D"));
		Destroy(gameObject.GetComponent ("BoxCollider2D"));
	}
	
	//Moves the shape
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		gameObject.transform.position = curPosition;
	}
	
	//Commits the shape's position and reset it's properties
	void OnMouseUp(){
		gameObject.AddComponent("Rigidbody2D");
		gameObject.AddComponent("BoxCollider2D");
		rigidbody2D.gravityScale = gravityScale;
	}
}
