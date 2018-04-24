using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

    public GameObject PlayerUnitPrefab;

    // Use this for initialization
    void Start () {
        
        if(!isLocalPlayer) {
            // this object is owned by another player
            return;
        }

        /* Player object is invisible and not part of the world
         give me something physical to move around */
        Debug.Log("PlayerObject::Start -- Spawning my own personal player unit");

        /* instantiate() only creates an object on the local comp even if it has a NetworkID
         it still will not exist on the network and therefore not on any other client 
         unless networkserver.spawn() is called on this object */
        // Instantiate(PlayerUnitPrefab);

        // Command server to spawn our unit
        CmdSpawnMyUnit();
        
	}

	
	// Update is called once per frame
	void Update () {
		//Update runs on everyone's computer whether or not they own this particular player object
	}

    /* Commands */
    // Commands are special functions athat only get executed on server

    [Command]
    void CmdSpawnMyUnit() {
        // guarantee to be on server right now
        GameObject go = Instantiate(PlayerUnitPrefab);

        //now that the object exists on the server, propogate it to all the clients and wire up network identity
        NetworkServer.Spawn(go);
    }
}
