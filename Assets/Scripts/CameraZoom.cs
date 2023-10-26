using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomInSpeed = 5.0f;   // Adjust the zoom in speed as needed.
    public float zoomOutSpeed = 5.0f;  // Adjust the zoom out speed as needed.
    public float minFieldOfView = 5.0f; // Adjust the minimum field of view for maximum zoom in.
    public float maxFieldOfView = 100.0f; // Adjust the maximum field of view for maximum zoom out.

    void Update()
    {
        // Get the current camera's field of view.
        float currentFieldOfView = Camera.main.fieldOfView;

        // Zoom in when the up arrow key is pressed.
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentFieldOfView -= zoomInSpeed * Time.deltaTime;
        }

        // Zoom out when the down arrow key is pressed.
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentFieldOfView += zoomOutSpeed * Time.deltaTime;
        }

        // Clamp the field of view within your specified limits.
        currentFieldOfView = Mathf.Clamp(currentFieldOfView, minFieldOfView, maxFieldOfView);

        // Apply the updated field of view to the camera.
        Camera.main.fieldOfView = currentFieldOfView;
    }
}
