using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillBrusch : IBrusch
{
    public void Paint(BruschInfo bruschInfo)
    {
        int x = bruschInfo.xPos;
        int y = bruschInfo.yPos;
        int height = bruschInfo.grid.Height;
        int width = bruschInfo.grid.Width;
        MyTile[,] tiles = bruschInfo.grid.Tiles;
        Color currentColor = tiles[x, y].colorTile.CurrentColor;
        Queue<ColorTile> openTiles = new Queue<ColorTile>();
        HashSet<ColorTile> closedTiles = new HashSet<ColorTile>();
        openTiles.Enqueue(tiles[x, y].colorTile);
        while(openTiles.Count > 0)
        {
            ColorTile currentTile = openTiles.Dequeue();
            x = (int)currentTile.Tile.gridPos.x;
            y = (int)currentTile.Tile.gridPos.y;
            List<ColorTile> tempList = new List<ColorTile>();
            tempList.Add(currentTile.North);
            tempList.Add(currentTile.East);
            tempList.Add(currentTile.South);
            tempList.Add(currentTile.West);
            foreach (ColorTile c in tempList)
            {
                if(c != null &&!closedTiles.Contains(c) && !openTiles.Contains(c)&& currentColor == c.CurrentColor )
                {
                    openTiles.Enqueue(c);
                }
            }
            if (!closedTiles.Contains(currentTile))
            {
                closedTiles.Add(currentTile);
            }
        }
        foreach(ColorTile c in closedTiles)
        {
            c.Paint(bruschInfo.currentColor);
        }
    }

    bool AllowedPos(int x, int y, int height, int width)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

}
