using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private Camera camera;
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float cameraMovementSpeed;
    [SerializeField] private float cameraMovementSpeedWithKeys;


    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        MoveCameraWithKeys();
        ZoomCamera();
    }

    //Checks for input and moves the camera after the input
    private void MoveCameraWithKeys()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * cameraMovementSpeedWithKeys;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * cameraMovementSpeedWithKeys;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * cameraMovementSpeedWithKeys;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * cameraMovementSpeedWithKeys;
        }
    }

    private void ZoomCamera()
    {
        if (AllowedToZoom())
        {
            // Is minus becuase otherwise it zooms the wrong way.
            camera.orthographicSize -= Input.mouseScrollDelta.y * scrollSpeed;
        }
    }


    //Checks if the cameras zoom is whitin the allowed range
    bool AllowedToZoom()
    {
        float size = camera.orthographicSize;
        //Is reversed becuase we subtract the value in ZoomCamera
        if(Input.mouseScrollDelta.y < 0)
        {
            return size < maxZoom;
        }
        else if(Input.mouseScrollDelta.y > 0)
        {
            return size > minZoom;
        }
        return false;
    }

    public void ResetCamera()
    {
        transform.position = Vector2.zero;
        camera.orthographicSize = 5; // 5 is the starting pos
    }

    //Moves the camera with the Ui Buttons
    public void MoveCameraWithUI(Vector3 dir)
    {
        transform.position += dir * cameraMovementSpeed;
    }
    
}
