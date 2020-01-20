using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BruschInfo is used to store information on which tile has been pressed and is used when the brusches paint.
// It contains the tiles x and y position. The entire grid is needed since some brusches color neigbouring tiles.
//And lastly currentcolor is which color to be used.
public struct BruschInfo{

    public readonly int xPos;
    public readonly int yPos;
    public readonly GridBehaviour grid;
    public readonly Color currentColor;

    public BruschInfo(int xPos, int yPos, GridBehaviour grid, Color currentColor)
    {
        this.xPos = xPos;
        this.yPos = yPos;
        this.grid = grid;
        this.currentColor = currentColor;
    }
}
