using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class King : ChessPiece {

	// Use this for initialization
	public override void Start () {
		string ID = GetComponent<NetworkIdentity> ().netId.ToString();
		this.transform.name = "King " + ID;
		base.Start ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Movement ()
	{
		base.Movement ();
	}
}
