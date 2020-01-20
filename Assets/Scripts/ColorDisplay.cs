using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Part of the UI. This script handles the creation of the color Display.
public class ColorDisplay : MonoBehaviour {
    [SerializeField] private Button showColors;
    [SerializeField] private GameObject colorDisplay;
    [SerializeField] private GameObject colorButtons;
    [SerializeField] private Transform colorPanel;
    private SEManager seManager;

    [SerializeField] private Color[] colors;

    private void Awake()
    {
        seManager = FindObjectOfType<SEManager>();
        SetAlphaToOne();
        CreateColors();
        AddFullAlphaColor();
        colorDisplay.SetActive(false);
        showColors.onClick.AddListener(() => colorDisplay.SetActive(!colorDisplay.activeSelf));
    }

    //Makes sure all colors are fully visible since unity seems to set the alpha to zero
    //When picking colors in the color wheel.
    void SetAlphaToOne()
    {
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i].a = 1;
        }
    }

    //Creates the buttons that you can pick colors on
    void CreateColors()
    {
        foreach(Color c in colors)
        {
            GameObject temp = Instantiate(colorButtons, colorPanel);
            temp.GetComponent<Image>().color = c;
            temp.GetComponent<Button>().onClick.AddListener( delegate { SetColorRefrence(c); });
        }
    }

    //When a color button is pressed the current color is changed 
    //Here a refernce is set so the sprite editor manager changes the current color
    void SetColorRefrence(Color c)
    {
        seManager.CurrentColor = c;
        colorPanel.gameObject.SetActive(false);
        showColors.GetComponent<Image>().color = c;
    }

    //A color that has full transpancy is added tp the color list.
    void AddFullAlphaColor()
    {
        GameObject temp = Instantiate(colorButtons, colorPanel);
        Color c = new Color(0, 0, 0, 0);
       
        temp.GetComponent<Button>().onClick.AddListener(delegate { SetColorRefrence(c); });
        temp.GetComponent<Button>().GetComponentInChildren<Text>().text = "A";
    }

}
