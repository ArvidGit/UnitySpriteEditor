using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sprite editor manager
public class SEManager : MonoBehaviour {
    [SerializeField] private Transform tileHolder;
    private GridBehaviour grid;
    private IBrusch currentBrusch;

    public Color CurrentColor
    {
        get; set;
    }

    public int MapWidth
    {
        get { return grid.Width; }
    }
    public int MapHeight
    {
        get { return grid.Height; }
    }
    
    public GridBehaviour Grid
    {
        get { return grid; }
    }

	void Awake () {
        CurrentColor = Color.white;
        grid = FindObjectOfType<GridBehaviour>();
        currentBrusch = new StandardBrusch();
	}
	
    //Resets all the colors of the tiles to white
    public void ResetColors()
    {
        foreach(Transform t in tileHolder)
        {
            t.GetComponent<ColorTile>().ResetColor();
        }
    }

    //Sets the alpha value of each tile to the opposite of the current one
    public void FullAlpha(int a)
    {
        foreach (Transform t in tileHolder)
        {
            t.GetComponent<ColorTile>().FullAlpha(a);
        }
    }

    //Calls the save manager to save a png
    public void Save()
    {
        FindObjectOfType<SaveManager>().Save(grid.Height, grid.Width, tileHolder);
    }

    //Calls load manager to load a specific png
    public void Load()
    {
        GetComponent<LoadManager>().Load();
    }
    
    //Creates a bruschinfo objext that stores all info needed to paint a tile.
    public void OnMousePress(ColorTile colorTile)
    {
        BruschInfo bruschInfo = new BruschInfo((int)colorTile.Tile.gridPos.x, (int)colorTile.Tile.gridPos.y,  grid, CurrentColor);
        currentBrusch.Paint(bruschInfo);
    }

    public void ChangeBrusch(int index)
    {
        currentBrusch = BruschFactory.GetBrusch(index);
    }

}
