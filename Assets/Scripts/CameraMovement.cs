using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float CameraMovementSpeed { get; set; }

	public void MoveCamera(Vector3 dir)
    {
        transform.position += dir * CameraMovementSpeed;
    }
}
