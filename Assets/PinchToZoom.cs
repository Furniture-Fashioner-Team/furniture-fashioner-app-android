using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchToZoom : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 currentScale;

    private bool isScaling = false;

    private void Start()
    {
        initialScale = transform.localScale;
        currentScale = initialScale;
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touch0.position, touch1.position);
                initialScale = currentScale; // Store the current scale when the pinch gesture begins
                isScaling = true;
            }
            else if (touch0.phase == TouchPhase.Moved || touch1.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch0.position, touch1.position);
                float scaleFactor = currentDistance / initialDistance;

                // Apply the scaling to the object's local scale
                currentScale = initialScale * scaleFactor;
                transform.localScale = currentScale;
            }
        }
        else if (isScaling && (Input.touchCount == 0 || Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended))
        {
            // Pinch gesture ended, but remember the current scale
            initialScale = currentScale;
            isScaling = false;
        }
    }
}