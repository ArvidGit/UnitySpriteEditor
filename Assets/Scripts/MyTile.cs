using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains basic info about the tile.
public struct MyTile{

    public readonly GameObject tile;
    public readonly Vector2 worldPos;
    public readonly Vector2 gridPos;
    public readonly ColorTile colorTile;

    public MyTile(GameObject tile, Vector2 worldPos, Vector2 gridPos, ColorTile colorTile)
    {
        this.tile = tile;
        this.worldPos = worldPos;
        this.gridPos = gridPos;
        this.colorTile = colorTile;
    }
}
