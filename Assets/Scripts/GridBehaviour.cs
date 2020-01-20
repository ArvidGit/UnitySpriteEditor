using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Both creates and maintains the grid.

public class GridBehaviour : MonoBehaviour {
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private GameObject tile;
    private float baseOffset = 4.6f;
    private float offset = 4.6f; //base offset will be recalculated only work for squares
    [SerializeField] private Transform tileHolder;
    private MyTile[,] tiles;
    public MyTile[,] Tiles
    {
        get { return tiles; }
    }
    //Properties don't show up in the unity inspector so have to have an underlying variable.
    public int Width
    {
        get { return width; }
    }
    public int Height
    {
        get { return height; }
    }

	void Start () {
        CreateGrid();
	}
	
	void Update () {
		
	}

    //Creates all the tiles.
    //Also setups the colortiles
    //This is very slow becuase gameobjects are quite slow and the program will crash if you create to many tiles at once.
    //Want to try to use something other then the tiles in the future and see if that speeds things up.
    void CreateGrid()
    {
        offset = RescaleOffset();
        Vector2 spawnPosition = GetMiddlePos();
        tiles = new MyTile[width, height];
        for(int i = 0; i < height; i++)
        {
            for(int k = 0; k < width; k++)
            {
                Vector3 spawnPos = new Vector3(spawnPosition.x + (k * offset), spawnPosition.y + (i * offset), 0);
                GameObject temp = Instantiate(tile, spawnPos, Quaternion.identity, tileHolder);
                ColorTile colorTile = temp.GetComponent<ColorTile>();
                MyTile currentTile = new MyTile(temp, spawnPos, new Vector2(k, i), colorTile);
                tiles[k, i] = currentTile;
                temp.GetComponent<ColorTile>().OnStart(currentTile);
            }
        }
    }
    
    //Assumes that tile is a square
    //Basically calculates the distance between two squares so we can use it as an offset when we create the grid.
    float RescaleOffset() 
    {
        float scale = tile.transform.localScale.y * baseOffset;
        return scale;
    }

    //Gets the center position of the grid.
    Vector2 GetMiddlePos()
    {
        int x = width / 2;
        int y = height / 2;
        Vector2 pos = new Vector2(x * offset, y * offset);
        return pos*-1;
    }
    
    //This is extremly bad and needs to be redone.
    //Takes forever and might crash the entire appliction.
    public void RescaleGrid(int width, int height)
    {
        foreach(Transform t in tileHolder)
        {
            Destroy(t.gameObject);
        }
        this.width = width;
        this.height = height;
        CreateGrid();

    }
}
