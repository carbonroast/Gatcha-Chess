using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	Vector2 boardSize;
	//Contains all the Tiles
	private static Dictionary<string, GameObject> tiles = new Dictionary<string, GameObject>();
	//The board
	public static Dictionary<Vector2, string> board = new Dictionary<Vector2, string> ();

	public static void RegisterTile (string netID, GameObject tileGO,Vector2 coord){
		board.Add (coord, netID);
		tiles.Add (netID, tileGO);
	}
	public static bool TileExistAt(Vector2 coord){
		if (board.ContainsKey (coord)) {
			//Debug.Log("Found Tile at : " +coord);
			return true;
		} else {
			//Debug.Log("Did Not Find Tile at : " +coord);
			return false;
		}
	}
	public static GameObject GetTileAt(Vector2 coord){
		if (board.ContainsKey (coord)) {
			string id = board [coord];
			//Debug.Log("Return Tile at : " +coord);
			return tiles [id];
		} else {
			//Debug.Log("Tile DOes Not Exist");
			return null;
		}
	}


}
