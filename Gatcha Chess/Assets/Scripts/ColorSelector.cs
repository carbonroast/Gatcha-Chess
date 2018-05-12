using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorSelector : MonoBehaviour {
	public GameObject buttonPrefab;
	public Canvas panel;
	// Use this for initialization
	void Start () {
		Canvas canvas = Canvas ();
		White (canvas);
		Black (canvas);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Canvas Canvas(){
		Canvas canvas = (Canvas) Instantiate (panel);
		return canvas;
	}
	void White(Canvas canvas){
		GameObject white = (GameObject) Instantiate (buttonPrefab);
		white.transform.SetParent (canvas.transform);
		white.GetComponent<Button> ().onClick.AddListener (OnClick);
		white.transform.GetChild (0).GetComponent<Text> ().text = "White";
		white.transform.localPosition = new Vector3 (0, 0, 0);
	}

	void Black(Canvas canvas){
		GameObject Black = (GameObject) Instantiate (buttonPrefab);
		Black.transform.SetParent (canvas.transform);
		Black.GetComponent<Button> ().onClick.AddListener (OnClick2);
		Black.transform.GetChild (0).GetComponent<Text> ().text = "Black";
		Black.transform.localPosition = new Vector3 (1, 0, 1);
	}
	void OnClick(){
		Debug.Log ("OnCLick");
	}
	void OnClick2(){
		Debug.Log ("OnCLick");
	}
	void ChoseColor(int Color){
		Debug.Log ("Color is : " + Color);
	}
}
