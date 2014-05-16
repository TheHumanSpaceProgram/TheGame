using UnityEngine;
using System.Collections;

public class PointPopupMovement : MonoBehaviour {
	private float timeStarted;
	private float fadeTime = 2;
	public bool exists = false;
	public string text;

	// Use this for initialization
	void Start () {
		timeStarted = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(exists){
			guiText.text = text;
			transform.Translate(new Vector3(0f, 0.001f, 0f));
			//float temp = guiText.material.color.a;
			float temp = Mathf.Cos ((Time.time - timeStarted) * (Mathf.PI/2)/fadeTime);
			guiText.material.color = new Color(guiText.material.color.r, guiText.material.color.g, guiText.material.color.b, temp);

			Destroy(gameObject, fadeTime);
		}

	}
}
