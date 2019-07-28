using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
