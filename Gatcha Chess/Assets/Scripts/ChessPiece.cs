using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChessPiece : NetworkBehaviour {
	[SyncVar]
	public Vector2 currentTile;
	// Use this for initialization
	public virtual void Start () {
		ChessPieceManager.RegisterPiece (this.transform.name, this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Movement(){

	}

	public virtual void SpecialMovement(){

	}

	public virtual void Color(){

	}
}
