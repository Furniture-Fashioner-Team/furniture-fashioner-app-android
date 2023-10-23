using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Test script used for simulating camera rotation during regular use
public class TestCameraRotation : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotation speed in degrees per second

    // The Update() method is called once per frame and is used for input handling
    private void Update()
    {
        // Handle camera rotation using keyboard input (wasd / arrow keys)
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