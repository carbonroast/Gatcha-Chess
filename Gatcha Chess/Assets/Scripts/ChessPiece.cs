using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChessPiece : NetworkBehaviour {
	[SyncVar]
	public Vector2 currentTile;
	public string Color;
	public bool selected;
	// Use this for initialization
	public virtual void Start () {
		ChessPieceManager.RegisterPiece (this.transform.name, this.gameObject);
		this.gameObject.layer = LayerMask.NameToLayer ("Piece");

	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			Movement ();
		}
	}

	public virtual void Movement(){

	}

	public virtual void SpecialMovement(){

	}


	public virtual void SetColor(){

	}



}
