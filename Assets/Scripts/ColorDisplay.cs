using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void SetAlphaToOne()
    {
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i].a = 1;
        }
    }

    void CreateColors()
    {
        foreach(Color c in colors)
        {
            GameObject temp = Instantiate(colorButtons, colorPanel);
            temp.GetComponent<Image>().color = c;
            temp.GetComponent<Button>().onClick.AddListener( delegate { SetColorRefrence(c); });
        }
    }

    void SetColorRefrence(Color c)
    {
        seManager.CurrentColor = c;
        colorPanel.gameObject.SetActive(false);
        showColors.GetComponent<Image>().color = c;
    }

    void AddFullAlphaColor()
    {
        GameObject temp = Instantiate(colorButtons, colorPanel);
        Color c = new Color(0, 0, 0, 0);
       
        temp.GetComponent<Button>().onClick.AddListener(delegate { SetColorRefrence(c); });
        temp.GetComponent<Button>().GetComponentInChildren<Text>().text = "A";
    }

}
