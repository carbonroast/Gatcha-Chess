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
		CmdCreateBoard ();
		AddPieces ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	[Command]
	void CmdCreateBoard(){
		GameObject board = new GameObject ();
		board.AddComponent<NetworkIdentity> ();
		board.transform.name = "Board";
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
			}
		}
	}

	void AddPieces(){
		SpawnQueen ();
		SpawnBishop ();
	}
	[Command]
	void CmdSetOccupied(Vector2 coord){
		GameObject tile = TileManager.GetTileAt (coord);
		Debug.Log ("CMD Occupied: " + tile.GetComponent<Tile> ().occupied);
		tile.GetComponent<Tile> ().occupied = true;
		Debug.Log ("CMD Occupied: " + tile.GetComponent<Tile> ().occupied);
		RpcSetOccupied (coord);
	}
	[ClientRpc]
	void RpcSetOccupied(Vector2 coord){
		GameObject tile = TileManager.GetTileAt (coord);
		Debug.Log ("RPC Occupied: " + tile.GetComponent<Tile> ().occupied);
		tile.GetComponent<Tile> ().occupied = true;
		Debug.Log ("RPC Occupied: " + tile.GetComponent<Tile> ().occupied);
	}
	void SpawnQueen(){
//		int x = Random.Range (0, (int)BoardSize.x);
//		int y = Random.Range (0, (int)BoardSize.y);
		int x = 3;
		int y = 3;
		bool openSpot = TileManager.GetTileAt (new Vector2 (x, y)).GetComponent<Tile> ().occupied;
		if (!openSpot) {
			GameObject queen = (GameObject)Instantiate (Queen);
			queen.GetComponent<Queen> ().currentTile = new Vector2 (x, y);
			queen.transform.position = TileManager.GetTileAt (new Vector2 (x, y)).transform.position + new Vector3 (0, 1, 0);

			NetworkServer.Spawn (queen);
			GameObject tile = TileManager.GetTileAt (new Vector2 (x, y));
			Debug.Log ("CMD Occupied: " + tile.GetComponent<Tile> ().occupied);
			tile.GetComponent<Tile> ().occupied = true;
			Debug.Log ("CMD Occupied: " + tile.GetComponent<Tile> ().occupied);

			//CmdSetOccupied(new Vector2 (x, y));
		} else {
			//Debug.Log(new Vector2(x,y) + " was Taken");
		}
	}
	void SpawnBishop(){
//		int x = Random.Range (0, (int)BoardSize.x);
//		int y = Random.Range (0, (int)BoardSize.y);
		int x = 4;
		int y = 3;
		bool openSpot = TileManager.GetTileAt (new Vector2 (x, y)).GetComponent<Tile> ().occupied;
		if (!openSpot) {
			GameObject bishop = (GameObject)Instantiate (Bishop);
			bishop.GetComponent<Bishop> ().currentTile = new Vector2 (x, y);
			bishop.transform.position = TileManager.GetTileAt (new Vector2 (x, y)).transform.position + new Vector3 (0, 1, 0);
			TileManager.GetTileAt (new Vector2 (x, y)).GetComponent<Tile> ().occupied = true;
			NetworkServer.Spawn (bishop);
		} else {
			//Debug.Log(new Vector2(x,y) + " was Taken");
		}
	}
}
