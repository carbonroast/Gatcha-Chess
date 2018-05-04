using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CreateGame : NetworkBehaviour {
	public GameObject Tile;


	public static Vector2 BoardSize = new Vector2(8,8);

	[SerializeField]
	private GameObject Queen, Bishop;


	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}
		CreateBoard ();
		FillBoard ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void CreateBoard(){
		GameObject board = new GameObject ();
		board.AddComponent<NetworkIdentity> ();
		board.transform.name = "Board";
		bool isblack = true;
		for (int x = 0; x < BoardSize.x; x++) {
			for (int y = 0; y < BoardSize.y; y++) {
				GameObject tileBlock = (GameObject)Instantiate (Tile);
				tileBlock.transform.position = new Vector3 (x,0, y);
				tileBlock.transform.parent = board.transform;
				NetworkServer.Spawn (tileBlock);
				string ID = tileBlock.GetComponent<NetworkIdentity> ().netId.ToString();
				tileBlock.transform.name = "Tile " + ID;
				tileBlock.GetComponent<Tile> ().Coord = new Vector2 (x, y);
				tileBlock.GetComponent<Tile> ().occupied = false;
				TileManager.RegisterTile (tileBlock.transform.name, tileBlock.gameObject,new Vector2(x,y));
				Renderer rend = tileBlock.GetComponent<Renderer> ();
				if (isblack) {
					rend.material.SetColor ("_Color", Color.black);

				} else {
					rend.material.SetColor ("_Color", Color.white);
				}
				isblack = !isblack;
			}
			isblack = !isblack;
		}

	}

	void FillBoard(){
		//Pawns

		//Bishop

		//Rook

		//Knight

		//Queen
		AddPiece(Queen, new Vector2(3,0));
		//King
	}

	void AddPiece(GameObject piece, Vector2 coord){
		bool openSpot = TileManager.GetTileAt (coord).GetComponent<Tile> ().occupied;
		if (!openSpot) {
			GameObject _piece = (GameObject)Instantiate (piece);
			_piece.GetComponent<ChessPiece> ().currentTile = coord;
			_piece.transform.position = TileManager.GetTileAt (coord).transform.position + new Vector3 (0, .5f, 0);
			NetworkServer.Spawn (_piece);
			GameObject tile = TileManager.GetTileAt (coord);
			tile.GetComponent<Tile> ().occupied = true;
		} 
	}

}
