using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Has all the UI components in it.
//This should probably be refactored in to smaller classes.
//Sets all the refernces for the different UI elements in the scene.
public class UIManager : MonoBehaviour {
    [SerializeField] private Button resetButton;
    [SerializeField] private Button UpButton;
    [SerializeField] private Button DownButton;
    [SerializeField] private Button RightButton;
    [SerializeField] private Button LeftButton;
    [SerializeField] private Button fullAlphaButton;
    [SerializeField] private InputField heightInput;
    [SerializeField] private InputField widthInput;
    [SerializeField] private Button saveButton;
    [SerializeField] private Button loadButton;
    [SerializeField] private Dropdown bruschesDropdown;
    private bool fullAlpha = false;
    private SEManager semanager;
    
	void Start () {
        CameraMovement cam = FindObjectOfType<CameraMovement>();
        semanager = GetComponent<SEManager>();
        resetButton.onClick.AddListener(delegate { semanager.ResetColors(); });
        UpButton.onClick.AddListener(() => cam.MoveCameraWithUI(Vector3.up));
        DownButton.onClick.AddListener(() => cam.MoveCameraWithUI(Vector3.down));
        RightButton.onClick.AddListener(() => cam.MoveCameraWithUI(Vector3.right));
        LeftButton.onClick.AddListener(() => cam.MoveCameraWithUI(Vector3.left));
        fullAlphaButton.onClick.AddListener(delegate { int a = fullAlpha ? 1 : 0; fullAlpha = !fullAlpha;  semanager.FullAlpha(a); });

        GridBehaviour grid = FindObjectOfType<GridBehaviour>();
        heightInput.text = grid.Height.ToString();
        widthInput.text = grid.Width.ToString();

        heightInput.onEndEdit.AddListener(delegate { grid.RescaleGrid(int.Parse(heightInput.text), int.Parse(widthInput.text)); });
        widthInput.onEndEdit.AddListener(delegate { grid.RescaleGrid(int.Parse(heightInput.text), int.Parse(widthInput.text)); });
        saveButton.onClick.AddListener(() => semanager.Save());
        FillBruschDropDown();
        bruschesDropdown.onValueChanged.AddListener(delegate { semanager.ChangeBrusch(bruschesDropdown.value); });
        loadButton.onClick.AddListener(() => semanager.Load());
    }


    void FillBruschDropDown()
    {
        List<string> m_DropOptions = new List<string>();
        for(int i =0; i < (int)Brusches.index; i++)
        {
            Brusches b = (Brusches)i;
            m_DropOptions.Add(b.ToString());
        }
        bruschesDropdown.ClearOptions();
        bruschesDropdown.AddOptions(m_DropOptions);
    }
    

}
