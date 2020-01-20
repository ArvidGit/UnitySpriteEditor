using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fills out an entire area with a single color were the tiles has the same color as the tile that was pressed.

public class FillBrusch : IBrusch
{
    //Uses breadth first search (BFS).
    public void Paint(BruschInfo bruschInfo)
    {
        //Setting up alot of values that will be needed.
        int x = bruschInfo.xPos;
        int y = bruschInfo.yPos;
        int height = bruschInfo.grid.Height;
        int width = bruschInfo.grid.Width;
        MyTile[,] tiles = bruschInfo.grid.Tiles;
        Color currentColor = tiles[x, y].colorTile.CurrentColor;


        Queue<ColorTile> openTiles = new Queue<ColorTile>();
        //Hashset contains method is O(1) so it's great for storing the already visited tiles.
        HashSet<ColorTile> closedTiles = new HashSet<ColorTile>();
        openTiles.Enqueue(tiles[x, y].colorTile);
        //BFS is used. First all nondiagonal neighbours are added to a temporary list.
        //then we check if the tile exists or if it has already been evaluated or if it has the same color as the original tile.
        //If it passes all the conditions its added to the open list. After that the currently evaluated node is added to the closedlist.
        //Lastly we paint all the nodes that is in the closedtiles set 
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
                if(c != null && !closedTiles.Contains(c) && !openTiles.Contains(c) && currentColor == c.CurrentColor )
                {
                    openTiles.Enqueue(c);
                }
            }
            if (!closedTiles.Contains(currentTile))
            {
                closedTiles.Add(currentTile);
            }
        }
        //Hashsets aren't as good for iteration though.
        foreach(ColorTile c in closedTiles)
        {
            c.Paint(bruschInfo.currentColor);
        }
    }

  

}
