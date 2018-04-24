using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tile : NetworkBehaviour {
	public Vector2 Coord;
	// Use this for initialization
	void Start () {
		CmdChangeName ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	void CmdChangeName(){
		this.transform.name = this.transform.name;
		RpcChangeName ();
	}

	[ClientRpc]
	void RpcChangeName(){
		this.transform.name = this.transform.name;
	}
}
