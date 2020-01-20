using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

//Used to save images as png.
public class SaveManager : MonoBehaviour{

    [SerializeField] private RenderTexture RTexture;
    [SerializeField] private Camera saveCamera;

    public void Save(int mapHeight, int mapWidth, Transform tileHolder)
    {
        StartCoroutine(CoSave(mapHeight, mapWidth, tileHolder));
    }

    private IEnumerator CoSave(int mapHeight, int mapWidth, Transform tileHolder)
    {
        //wait for camera to render
        yield return new WaitForEndOfFrame();
        if (saveCamera.targetTexture != null)
        {
            saveCamera.targetTexture.Release();
        }
        RTexture = new RenderTexture(mapWidth, mapHeight, 24);
        saveCamera.targetTexture = RTexture;
        RenderTexture.active = RTexture;

        //The texture to store the  png in
        var texture2D = new Texture2D(RTexture.width, RTexture.height);
        texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        texture2D.Apply();
        List<ColorTile> t = new List<ColorTile>();
        foreach (Transform et in tileHolder)
        {
            t.Add(et.GetComponent<ColorTile>());
        }
        //Foreach tile in the grid we set the color of a certain pixel in the texture to the color of a tile
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight ; j++)
            {
                texture2D.SetPixel(j, i, t[(i * mapHeight) + j].GetComponent<SpriteRenderer>().color);
            }
        }

        //write data to file
        var data = texture2D.EncodeToPNG();
        var path = EditorUtility.SaveFilePanel( "Save texture as PNG","",".png","png");

        File.WriteAllBytes(path, data);
    }

}
