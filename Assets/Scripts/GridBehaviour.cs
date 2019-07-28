using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int Width
    {
        get { return width; }
    }
    public int Height
    {
        get { return height; }
    }
	// Use this for initialization
	void Start () {
        CreateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateGrid()
    {
        offset = RescaleOffset();
        Vector2 spawnPosition = GetMiddlePos();
        FindObjectOfType<CameraMovement>().CameraMovementSpeed = offset;
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


    float RescaleOffset() // assumes that tile is a square
    {
        float scale = tile.transform.localScale.y *baseOffset;
        return scale;
    }

    Vector2 GetMiddlePos()
    {
        int x = width / 2;
        int y = height / 2;
        Vector2 pos = new Vector2(x * offset, y * offset);
        return pos*-1;
    }

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
