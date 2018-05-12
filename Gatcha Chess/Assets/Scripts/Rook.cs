using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Rook : ChessPiece
{
    Vector2 movement = new Vector2(8, 8);
    // Use this for initialization
    public override void Start()
    {
        string ID = GetComponent<NetworkIdentity>().netId.ToString();
        this.transform.name = "Queen " + ID;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Movement()
    {
        List<Vector2> canMove = new List<Vector2>();
        bool hitPiece = false;
        //Horizontals
        for (int x = 0; x < movement.x; x++)
        {
            if (x != currentTile.x && hitPiece == false)
            {
                Vector2 tileLocation = new Vector2(x, currentTile.y);
                bool tileExist = TileManager.TileExistAt(tileLocation);
                hitPiece = TileManager.GetTileAt(tileLocation).GetComponent<Tile>().occupied;
                if (hitPiece)
                {
                   // Debug.Log("Piece in way");
                }
                if (tileExist)
                {
                    canMove.Add(tileLocation);
                }
            }

        }
        hitPiece = false;
        for (int y = 0; y < movement.x; y++)
        {
            if (y != currentTile.y && hitPiece == false)
            {
                Vector2 tileLocation = new Vector2(currentTile.x, y);
                bool tileExist = TileManager.TileExistAt(tileLocation);
                hitPiece = TileManager.GetTileAt(tileLocation).GetComponent<Tile>().occupied;
                if (hitPiece)
                {
                   // Debug.Log("Piece in way");
                }
                if (tileExist)
                {
                    canMove.Add(tileLocation);
                }
            }
        }
        
       
        foreach (Vector2 coord in canMove)
        {
            GameObject tile = TileManager.GetTileAt(coord);
            Renderer rend = tile.GetComponent<Renderer>();
			rend.material.SetColor("_Color", UnityEngine.Color.yellow);
        }
    }
}