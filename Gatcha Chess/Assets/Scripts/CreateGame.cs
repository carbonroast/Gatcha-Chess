using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateGame : NetworkBehaviour {
	public GameObject Tile;
	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}
		CmdCreateBoard ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[Command]
	void CmdCreateBoard(){
		GameObject board = new GameObject ();
		board.AddComponent<NetworkIdentity> ();
		board.transform.name = "Board";
		for (int x = 0; x < 8; x++) {
			for (int y = 0; y < 8; y++) {
				GameObject tileBlock = (GameObject)Instantiate (Tile);
				tileBlock.transform.position = new Vector3 (x,0, y);
				tileBlock.transform.parent = board.transform;
				NetworkServer.Spawn (tileBlock);
				string ID = tileBlock.GetComponent<NetworkIdentity> ().netId.ToString();
				tileBlock.transform.name = "Tile " + ID;
				tileBlock.GetComponent<Tile> ().Coord = new Vector2 (x, y);
				TileManager.RegisterPiece (tileBlock.transform.name, tileBlock.gameObject);
			}
		}
	}

	void AddPieces(){

	}
}
