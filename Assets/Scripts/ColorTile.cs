using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ColorTile : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private SpriteRenderer sr;
    private SEManager se;
    bool hover = false;
    private MyTile myTile;
    public MyTile Tile
    {
        get { return myTile; }
    }
    
    public Color CurrentColor
    {
        get { return sr.color; }
    }

    public ColorTile North { get; set; }
    public ColorTile East { get; set; }
    public ColorTile South { get; set; }
    public ColorTile West { get; set; }


    private void Awake()
    {
        se = FindObjectOfType<SEManager>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        SetNeighbours();
    }

    void SetNeighbours()
    {
        int x = (int)myTile.gridPos.x;
        int y = (int)myTile.gridPos.y;
        if (AllowedPos(x, y + 1, se.MapHeight, se.MapWidth))
        {
            North = se.Grid.Tiles[x, y + 1].colorTile;
        }
        if (AllowedPos(x+1, y, se.MapHeight, se.MapWidth))
        {
            East = se.Grid.Tiles[x+1, y].colorTile;
        }
        if (AllowedPos(x, y - 1, se.MapHeight, se.MapWidth))
        {
            South = se.Grid.Tiles[x, y - 1].colorTile;
        }
        if (AllowedPos(x-1, y, se.MapHeight, se.MapWidth))
        {
            West = se.Grid.Tiles[x-1, y].colorTile;
        }
    }

    public void OnStart(MyTile myTile)
    {
        this.myTile = myTile;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && hover)
        {
            se.OnMousePress(this);
        }
    }
    //ui wouldnt block otherwise
    public void OnPointerEnter(PointerEventData eventData)
    {
        hover = true;
    }

    public void Paint(Color color)
    {
        sr.color = color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hover = false;
    }

    public void ResetColor()
    {
        sr.color = Color.white;
    }
    public void FullAlpha(int alpha)
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
    }
    bool AllowedPos(int x, int y, int height, int width)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
