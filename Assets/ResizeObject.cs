using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectResizer : MonoBehaviour
{
    public Slider sizeSlider; // Reference to your UI Slider
    public float minSize = 0.1f;
    public float maxSize = 2.0f;
    private Transform capsule;

    private void Start()
    {
        capsule = transform; // Assuming the script is attached to the object you want to resize
        sizeSlider.onValueChanged.AddListener(ResizeObject);
    }

    private void ResizeObject(float newSize)
    {
        // Clamp the size based on the Slider's min and max values
        float clampedSize = Mathf.Lerp(minSize, maxSize, newSize);

        // Apply the new scale to the object
        capsule.localScale = new Vector3(clampedSize, clampedSize, clampedSize);
    }
}
