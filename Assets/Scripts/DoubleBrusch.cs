using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The doublebrucsh can paint several nearby tiles 
//bruschsize tells how many tiles should be painted.
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

        //How many tiles that will be filled depends on the bruschsize.
        //A bruschsize of 1 will fill all the neighbouring tiles of tile[x,y]
        //A bruschsize of 2 will fill all the neighbouring tiles 
        //and all the tiles that are neighbours to the neighbouring tiles of tile[x,y]

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

    //Checks if a tile exists or not.
    bool AllowedPos(int x, int y, int height, int width)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
    
}
