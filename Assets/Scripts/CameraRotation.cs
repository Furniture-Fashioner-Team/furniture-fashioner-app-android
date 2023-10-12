using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotation speed in degrees per second

    private void Update()
    {
        // Handle camera rotation using keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        RotateCamera(horizontalInput, verticalInput);
    }

    private void RotateCamera(float horizontalInput, float verticalInput)
    {
        // Calculate the rotation angles
        float rotationX = verticalInput * rotationSpeed * Time.deltaTime;
        float rotationY = horizontalInput * rotationSpeed * Time.deltaTime;

        // Apply the rotations to the camera
        transform.Rotate(-rotationX, rotationY, 0);
    }
}