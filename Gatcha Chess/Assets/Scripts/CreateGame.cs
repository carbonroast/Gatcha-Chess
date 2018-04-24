using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateGame : NetworkBehaviour {
	public GameObject Tile;
	// Use this for initialization
	void Start () {
		CreateBoard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateBoard(){
		GameObject board = new GameObject ();
		board.AddComponent<NetworkIdentity> ();
		for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 8; y++) {
				GameObject tileBlock = (GameObject)Instantiate (Tile);
				tileBlock.transform.position = new Vector3 (x,0, y);
				tileBlock.transform.parent = board.transform;
			}
		}
	}

	void AddPieces(){

	}
}
