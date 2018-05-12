using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class King : ChessPiece
{
    Vector2 movement = new Vector2(8, 8);
    // Use this for initialization
    public override void Start()
    {
        string ID = GetComponent<NetworkIdentity>().netId.ToString();
        this.transform.name = "King " + ID;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Movement()
    {
        bool hitPiece = false;
        List<Vector2> canMove = new List<Vector2>();
        for (int x = 0; x < movement.x; x++)
        {
            for (int y = 0; y < movement.y; y++)
            {
                if (x != currentTile.x || y != currentTile.y)
                {
                    if (x < currentTile.x + 2 && x > currentTile.x - 2 && y < currentTile.y + 2 && y > currentTile.y - 2)
                    {
                        Vector2 tileLocation = new Vector2(x, y);
                        bool tileExist = TileManager.TileExistAt(tileLocation);

                        hitPiece = TileManager.GetTileAt(tileLocation).GetComponent<Tile>().occupied;
                        if (hitPiece)
                        {
                           // Debug.Log("Piece in way");
                        }
                        if (tileExist)
                        {
                            canMove.Add(tileLocation);
                            //Debug.Log("ADDED : " + tileLocation);
                        }
                    }
                }

            }
            foreach (Vector2 coord in canMove)
            {
                GameObject tile = TileManager.GetTileAt(coord);
                Renderer rend = tile.GetComponent<Renderer>();
                rend.material.SetColor("_Color", UnityEngine.Color.cyan);
            }
        }
    }
}