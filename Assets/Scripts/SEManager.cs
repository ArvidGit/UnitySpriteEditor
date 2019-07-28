using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Brusches
{
    Standard,
    Double,
    Triple,
    Fill,
    index
}

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

	// Use this for initialization
	void Awake () {
        CurrentColor = Color.white;
        grid = FindObjectOfType<GridBehaviour>();
        currentBrusch = new StandardBrusch();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetColors()
    {
        foreach(Transform t in tileHolder)
        {
            t.GetComponent<ColorTile>().ResetColor();
        }
    }
    public void FullAlpha(int a)
    {
        foreach (Transform t in tileHolder)
        {
            t.GetComponent<ColorTile>().FullAlpha(a);
        }
    }

    public void Save()
    {
        FindObjectOfType<SaveManager>().Save(grid.Height, grid.Width, tileHolder);
    }
    public void Load()
    {
        GetComponent<LoadManager>().Load();
    }

    public void OnMousePress(ColorTile colorTile)
    {
        BruschInfo bruschInfo = new BruschInfo((int)colorTile.Tile.gridPos.x, (int)colorTile.Tile.gridPos.y,  grid, CurrentColor);
        currentBrusch.Paint(bruschInfo);
    }

    public void ChangeBrusch(int index)
    {
        Brusches b = (Brusches)index;
        switch (b)
        {
            case Brusches.Standard:
                currentBrusch = new StandardBrusch();
                break;
            case Brusches.Double:
                currentBrusch = new DoubleBrusch(1);
                break;
            case Brusches.Triple:
                currentBrusch = new DoubleBrusch(2);
                break;
            case Brusches.Fill:
                currentBrusch = new FillBrusch();
                break;
            default:
                currentBrusch = new StandardBrusch();
                break;
        }
    }

}
