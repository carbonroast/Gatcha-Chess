using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour {
    public GameObject ChessPieceSpawn;
    public Transform spawnPoint;

    /*
	// Update is called once per frame
	public void Start () {
		if (!isLocalPlayer)
        {
            return;
        }
        cmdSpawnChesspieces();        
	}

    [Command]
    void cmdSpawnChesspieces()
    {
        GameObject go = Instantiate(ChessPieceSpawn, spawnPoint);
        NetworkServer.Spawn(go);
        Debug.Log("Spawned piece");
    }*/
}
