using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieceManager : MonoBehaviour {
	//Contains all the pieces
	private static Dictionary<string, GameObject> pieces = new Dictionary<string, GameObject>();

	public static void RegisterPiece (string netID, GameObject pieceGO){
		pieces.Add (netID, pieceGO);
	}
	
}
