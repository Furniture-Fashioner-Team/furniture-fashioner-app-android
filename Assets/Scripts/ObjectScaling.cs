using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ScaleWithDistance : MonoBehaviour
{
    public ARSessionOrigin arSessionOrigin;
    public float scaleMultiplier = 0.01f;

    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = arSessionOrigin.camera.transform;
    }

    private void Update()
    {
        // Calculates distance from camera to object
        float distance = Vector3.Distance(transform.position, cameraTransform.position);

        // Scale based on distance
        float newScale = distance * scaleMultiplier;
        transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
