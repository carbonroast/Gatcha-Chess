using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	//Contains all the Tiles
	private static Dictionary<string, GameObject> tiles = new Dictionary<string, GameObject>();

	public static void RegisterPiece (string netID, GameObject tileGO){
		tiles.Add (netID, tileGO);
	}
}
