using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBrusch : IBrusch {
    public void Paint(BruschInfo bruschInfo)
    {
        int x = bruschInfo.xPos;
        int y = bruschInfo.yPos;
        bruschInfo.grid.Tiles[x, y].colorTile.Paint(bruschInfo.currentColor);
    }

   
}
