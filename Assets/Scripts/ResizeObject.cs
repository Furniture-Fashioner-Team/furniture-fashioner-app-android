using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectResizer : MonoBehaviour
{
    public Slider sizeSlider; // Reference to your UI Slider
    public float minSize = 0.1f;
    public float maxSize = 2f;

    private Transform objectToResize;

    private float localScaleX;
    private float localScaleY;
    private float localScaleZ;

    private void Start()
    {
        objectToResize = transform; // Assuming the script is attached to the object you want to resize
        localScaleX = objectToResize.localScale.x;
        localScaleY = objectToResize.localScale.y;
        localScaleZ = objectToResize.localScale.z;
        sizeSlider.onValueChanged.AddListener(ResizeObject);
    }

    private void ResizeObject(float newSize)
    {
        // Clamp the size based on the Slider's min and max values
        float clampedSizeX = Mathf.Lerp(localScaleX * minSize, localScaleX * maxSize, newSize);
        float clampedSizeY = Mathf.Lerp(localScaleY * minSize, localScaleY * maxSize, newSize);
        float clampedSizeZ = Mathf.Lerp(localScaleZ * minSize, localScaleZ * maxSize, newSize);

        // Apply the new scale to the object
        objectToResize.localScale = new Vector3(clampedSizeX, clampedSizeY, clampedSizeZ);
    }
}