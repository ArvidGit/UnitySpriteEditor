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
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Load()
    {
        var filePath = EditorUtility.SaveFilePanel(
          "Save texture as PNG",
          "",
          ".png",
          "png");
      
        Texture2D texture = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);
        }
        grid.RescaleGrid(texture.width, texture.height);
        for (int i = 0; i < texture.width; i++)
        {
            for (int j = 0; j < texture.height; j++)
            {
                grid.Tiles[i,j].colorTile.Paint(texture.GetPixel(i, j));
                
            }
        }

    }

}
