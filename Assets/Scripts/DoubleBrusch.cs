using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBrusch : IBrusch {

    int bruschSize;
    public DoubleBrusch(int bruschSize)
    {
        this.bruschSize = bruschSize;
    }

    public void Paint(BruschInfo bruschInfo)
    {
        MyTile[,] tiles = bruschInfo.grid.Tiles;
        int x = bruschInfo.xPos;
        int y = bruschInfo.yPos;
        int height = bruschInfo.grid.Height;
        int width = bruschInfo.grid.Width;
        for(int i = -bruschSize; i <= bruschSize; i++)
        {
            for (int j = -bruschSize; j <= bruschSize; j++)
            {
                if (AllowedPos(x + i, y + j, height, width))
                {
                    tiles[x + i, y + j].colorTile.Paint(bruschInfo.currentColor);
                }

            }
        }
    }

    bool AllowedPos(int x, int y, int height, int width)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }

   
}
