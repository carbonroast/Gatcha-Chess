using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Tile : NetworkBehaviour {
	public Vector2 Coord;
	public bool occupied;
	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}
		occupied = false;
		StartCoroutine (Setup(transform.name));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Command]
	void CmdChangeName(string name){
		this.transform.name = name;
		RpcChangeName (name);
	}

	[ClientRpc]
	void RpcChangeName(string name){
		this.transform.name = name;
	}

	/*********************************************************** IEnumerator ************************************************/
	private IEnumerator Setup(string name)
	{
		//wait to be sure that all are ready to start
		yield return new WaitForSeconds(2.0f);
		CmdChangeName (name);
	}

}

