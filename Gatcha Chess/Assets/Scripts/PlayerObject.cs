using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {
    
    public GameObject Queen, Bishop, King, Rook;



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

        CmdSpawnPiece();
        
	}

	
	// Update is called once per frame
	void Update () {
        //Update runs on everyone's computer whether or not they own this particular player object

    }

    /* Commands */
    // Commands are special functions athat only get executed on server

    [Command]
    void CmdSpawnPiece() {
        
        AddPiece(King, new Vector2(3, 0));
        AddPiece(Queen, new Vector2(4, 0));
        AddPiece(Bishop, new Vector2(2, 0));
        AddPiece(Bishop, new Vector2(5, 0));
        AddPiece(Rook, new Vector2(0, 0));
        AddPiece(Rook, new Vector2(7, 0));
    }

    void AddPiece(GameObject piece, Vector2 coord)
    {
        bool openSpot = TileManager.GetTileAt(coord).GetComponent<Tile>().occupied;
        if (!openSpot)
        {
            GameObject _piece = (GameObject)Instantiate(piece);
            _piece.GetComponent<ChessPiece>().currentTile = coord;
            //_piece.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
            _piece.transform.position = TileManager.GetTileAt(coord).transform.position + new Vector3(0, 1, 0);
            NetworkServer.SpawnWithClientAuthority(_piece, connectionToClient);
            GameObject tile = TileManager.GetTileAt(coord);
            tile.GetComponent<Tile>().occupied = true;
        }
    }
}
