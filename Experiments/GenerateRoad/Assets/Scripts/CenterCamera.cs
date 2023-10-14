using UnityEngine;

public class CenterCameraOnPlane : MonoBehaviour
{
    public Transform planeTransform; // Drag the plane's transform here in the inspector.
    public float heightAbovePlane = 10f; // Adjust to control how high above the plane the camera should be.

    void Start()
    {
        // Position the camera above the plane.
        transform.position = new Vector3(planeTransform.position.x, heightAbovePlane, planeTransform.position.z);
        
        // Rotate the camera to look directly down.
        transform.rotation = Quaternion.Euler(90f, 180f, 0f);
    }
}
