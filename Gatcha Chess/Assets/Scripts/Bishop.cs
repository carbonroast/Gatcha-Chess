using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bishop : ChessPiece {
	Vector2 movement = new Vector2 (8,8);
	// Use this for initialization
	public override void Start () {
		string ID = GetComponent<NetworkIdentity> ().netId.ToString();
		this.transform.name = "Bishop " + ID;
		base.Start ();
		Movement ();
	}

	// Update is called once per frame
	void Update () {

	}

	public override void Movement (){
		List<Vector2> canMove = new List<Vector2>();
		Vector2 spotCheck = new Vector2 (currentTile.x, currentTile.y);
		//TopRight
		for (int x=(int)currentTile.x+1; x< CreateGame.BoardSize.x + (movement.x - currentTile.x); x++){
			Debug.Log ("X is " + x);
			for (int y = (int)currentTile.y + 1; y < CreateGame.BoardSize.y + (movement.y - currentTile.y); y++) {
				Debug.Log ("Y is " + y);
				if (new Vector2(x,y) == spotCheck  + new Vector2(1,1)) {
					
					Vector2 tileLocation = new Vector2 (x, y);
					bool tileExist = TileManager.TileExistAt (tileLocation);
					if (tileExist) {
						canMove.Add (tileLocation);
						Debug.Log ("ADDED : " + tileLocation);
						spotCheck = spotCheck + new Vector2(1,1);
					}
				}
			}
		}

		//BottomLeft
		spotCheck = new Vector2 (currentTile.x, currentTile.y);			
		for (int x=(int)currentTile.x - 1; x>=0; x--){
			for (int y = (int)currentTile.y - 1; y >= 0; y--) {
				if (new Vector2(x,y) == spotCheck  + new Vector2(-1,-1)) {
					Vector2 tileLocation = new Vector2 (x, y);
					bool tileExist = TileManager.TileExistAt (tileLocation);
					if (tileExist) {
						canMove.Add (tileLocation);
						Debug.Log ("ADDED : " + tileLocation);
						spotCheck = spotCheck + new Vector2(-1,-1);
					}
				}
			}
		}

		//TopLeft
		spotCheck = new Vector2 (currentTile.x, currentTile.y);		
		for (int x=(int)currentTile.x - 1; x>=0; x--){
			for (int y = (int)currentTile.y + 1; y < CreateGame.BoardSize.y + (movement.y - currentTile.y); y++) {
				if (new Vector2(x,y) == spotCheck  + new Vector2(-1,1)) {
					Vector2 tileLocation = new Vector2 (x, y);
					bool tileExist = TileManager.TileExistAt (tileLocation);
					if (tileExist) {
						canMove.Add (tileLocation);
						Debug.Log ("ADDED : " + tileLocation);
						spotCheck = spotCheck + new Vector2(-1,1);
					}
				}
			}
		}

		//BottomRight
		spotCheck = new Vector2 (currentTile.x, currentTile.y);			
		for (int x=(int)currentTile.x+1; x< CreateGame.BoardSize.x + (movement.x - currentTile.x); x++){
			for (int y = (int)currentTile.y - 1; y >= 0; y--) {
				if (new Vector2(x,y) == spotCheck  + new Vector2(1,-1)) {
					Vector2 tileLocation = new Vector2 (x, y);
					bool tileExist = TileManager.TileExistAt (tileLocation);
					if (tileExist) {
						canMove.Add (tileLocation);
						Debug.Log ("ADDED : " + tileLocation);
						spotCheck = spotCheck + new Vector2(1,-1);
					}
				}
			}
		}

//		foreach (Vector2 coord in canMove) {
//			GameObject tile = TileManager.GetTileAt (coord);
//			Renderer rend = tile.GetComponent<Renderer> ();
//			rend.material.SetColor ("_Color", Color.green);
//		}
	}
}
