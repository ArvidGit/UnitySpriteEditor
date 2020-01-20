using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LoadManager : MonoBehaviour {

    private GridBehaviour grid;

    void Start () {
        grid = FindObjectOfType<GridBehaviour>();
	}
	
	void Update () {
		
	}

    //Loads a png and recreates it with the tiles
    public void Load()
    {
        //Makes the windows explorer pop up
        var filePath = EditorUtility.SaveFilePanel("Save texture as PNG", "",".png","png");
      
        Texture2D texture = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2); //Initial size doesn't seem to matter
            texture.LoadImage(fileData);
        }
        else
        {
            return;
        }
        //Rescales the grid after the dimensions of the loaded picture
        grid.RescaleGrid(texture.width, texture.height);

        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                //Getpixel gets the color from a certain pixel of the loaded png and then we 
                //paint the tile with that color.
                grid.Tiles[i,j].colorTile.Paint(texture.GetPixel(i, j));
                
            }
        }

    }

}
